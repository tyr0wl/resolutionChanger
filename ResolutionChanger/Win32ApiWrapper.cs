using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ResolutionChanger.Data;
using ResolutionChanger.Data.Modes;
using ResolutionChanger.Data.Paths;
using ResolutionChanger.Win32;
using ResolutionChanger.Win32.DisplayConfig;
using ResolutionChanger.Win32.DisplayConfig.Data;
using ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes;
using ResolutionChanger.Win32.DisplayConfig.ModeInfo;
using ResolutionChanger.Win32.DisplayConfig.Modes;
using ResolutionChanger.Win32.DisplayConfig.Paths;

namespace ResolutionChanger
{
    public static class Win32ApiWrapper
    {
        internal static ModeInfo CreateSourceModeInfo(Monitor monitor)
        {
            var (adapterId, id) = monitor.SourceId;
            return new ModeInfo
            {
                adapterId = (LuId) adapterId,
                id = id,
                sourceMode = new SourceMode
                {
                    width = monitor.CurrentResolution.Width,
                    height = monitor.CurrentResolution.Height,
                    pixelFormat = PixelFormat.PixelFormat32Bpp,
                    position = PointL.FromPoint(monitor.Position)
                },
                infoType = ModeInfoType.Source
            };
        }

        internal static ModeInfo CreateTargetModeInfo(Monitor monitor)
        {
            var preferredMode = GetTargetPreferredMode(monitor.TargetId);
            var (adapterId, id) = monitor.SourceId;
            //preferredMode.targetMode.targetVideoSignalInfo.vSyncFreq.Numerator = monitor.CurrentResolution.Frequency;
            return new ModeInfo
            {
                adapterId = (LuId) adapterId,
                id = id,
                targetMode = preferredMode.targetMode,
                infoType = ModeInfoType.Target
            };
        }

        internal static AdapterName GetAdapterName(uint adapterId)
        {
            var requestPacket = new AdapterName
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(AdapterName)),
                    adapterId = (LuId) adapterId,
                    type = DeviceInfoType.GetAdapterName
                }
            };

            var error = DisplayConfigApi.DisplayConfigGetDeviceInfo(ref requestPacket);
            if (error != Win32Status.ErrorSuccess)
            {
                throw new Win32Exception((int) error);
            }

            return requestPacket;
        }

        public static (ScreenPath[] paths, ScreenMode[] modes) GetDisplayConfig()
        {
            return GetDisplayConfig(QueryDeviceConfigFlags.AllPaths);
        }

        public static (ScreenPath[] paths, ScreenMode[] modes) GetDisplayConfig(QueryDeviceConfigFlags configFlags)
        {
            var error = DisplayConfigApi.GetDisplayConfigBufferSizes(configFlags, out var pathCount, out var modeCount);
            if (error != (int) Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            var paths = new PathInfo[pathCount];
            var modes = new ModeInfo[modeCount];
            error = DisplayConfigApi.QueryDisplayConfig(configFlags, ref pathCount, paths, ref modeCount, modes, IntPtr.Zero);

            if (error != (int) Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            var wrappedPaths = paths.Select(ScreenPathFactory.Create).ToArray();
            var wrappedModes = modes.Select(ScreenModeFactory.Create).ToArray();
            return (wrappedPaths, wrappedModes);
        }

        internal static SourceDeviceName GetGdiDeviceNameFromSource(DeviceId deviceId)
        {
            return GetGdiDeviceNameFromSource((LuId) deviceId.AdapterId, deviceId.Id);
        }

        internal static SourceDeviceName GetGdiDeviceNameFromSource(LuId adapterId, uint id)
        {
            var requestPacket = new SourceDeviceName
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(SourceDeviceName)),
                    adapterId = adapterId,
                    id = id,
                    type = DeviceInfoType.GetSourceName
                }
            };

            var error = DisplayConfigApi.DisplayConfigGetDeviceInfo(ref requestPacket);
            if (error != Win32Status.ErrorSuccess)
            {
                throw new Win32Exception((int) error);
            }

            return requestPacket;
        }

        public static Monitor GetMonitor(ScreenPath path, ScreenMode[] modes)
        {
            var targetDeviceName = GetTargetDeviceName(path.TargetPath.DeviceId);
            return GetMonitor(path, modes, targetDeviceName);
        }
        
        internal static Monitor GetMonitor(ScreenPath path, ScreenMode[] modes, TargetDeviceName targetDeviceName)
        {
            var source = path.SourcePath;
            SourceScreenMode sourceMode = null;
            if (!source.InvalidModeIndex)
            {
                sourceMode = (SourceScreenMode) modes[source.ModeIndex];
            }

            var (isPrimary, resolution, point) = GetSourceModeInformation(sourceMode);

            var target = path.TargetPath;
            TargetScreenMode targetMode = null;
            if (!target.InvalidModeIndex)
            {
                targetMode = (TargetScreenMode) modes[target.ModeIndex];
            }

            resolution.Frequency = GetFrequency(targetMode);

            var monitor = new Monitor
            {
                SourceId = source.DeviceId,
                TargetId = target.DeviceId,
                DevicePath = targetDeviceName.monitorDevicePath,
                DisplayName = targetDeviceName.monitorFriendlyDeviceName,
                IsActive = path.Active,
                IsPrimary = isPrimary,
                CurrentResolution = resolution,
                Position = point
            };

            return monitor;
        }

        public static IList<Monitor> GetMonitors()
        {
            var (paths, modes) = GetDisplayConfig();

            // gdi, source,target,friendly,devicePath
            var monitors = new Dictionary<string, Monitor>();

            for (var index = 0; index < paths.Length; index++)
            {
                var path = paths[index];

                if (!path.TargetPath.Available)
                {
                    continue;
                }

                var source = path.SourcePath;
                var target = path.TargetPath;
                var sourceDeviceName = GetGdiDeviceNameFromSource(source.DeviceId);
                var adapterName = GetAdapterName(target.DeviceId.AdapterId);

                if (path.Active)
                {
                    var monitor = GetMonitor(path, modes);
                    monitors.Add(sourceDeviceName.viewGdiDeviceName, monitor);
                }
                else if (!source.InUse && !target.InUse && !monitors.ContainsKey(sourceDeviceName.viewGdiDeviceName))
                {
                    paths[index] = path.Copy(source.Copy(inUse: true, modeIndex: -1),
                                             target.Copy(inUse: true, modeIndex: -1),
                                             true);

                    var result = TestConfig(paths, modes);

                    if (result != Win32Status.ErrorSuccess)
                    {
                        paths[index] = path.Copy(source.Copy(inUse: false),
                                                 target.Copy(inUse: false),
                                                 false);
                    }
                    else
                    {
                        var monitor = GetMonitor(path, modes);
                        monitors.Add(sourceDeviceName.viewGdiDeviceName, monitor);
                    }
                }
            }

            return monitors.Values.ToList();
        }

        internal static TargetDeviceName GetTargetDeviceName(DeviceId deviceId)
        {
            return GetTargetDeviceName((LuId) deviceId.AdapterId, deviceId.Id);
        }
        
        internal static TargetDeviceName GetTargetDeviceName(LuId adapterId, uint id)
        {
            var deviceName = new TargetDeviceName
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(TargetDeviceName)),
                    adapterId = adapterId,
                    id = id,
                    type = DeviceInfoType.GetTargetName
                }
            };

            var error = DisplayConfigApi.DisplayConfigGetDeviceInfo(ref deviceName);
            if (error != (int) Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            return deviceName;
        }

        internal static TargetPreferredMode GetTargetPreferredMode(DeviceId deviceId)
        {
            var (adapterId, id) = deviceId;
            var requestPacket = new TargetPreferredMode
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(TargetPreferredMode)),
                    adapterId = (LuId) adapterId,
                    id = id,
                    type = DeviceInfoType.GetTargetPreferredMode
                }
            };

            var error = DisplayConfigApi.DisplayConfigGetDeviceInfo(ref requestPacket);
            if (error != Win32Status.ErrorSuccess)
            {
                throw new Win32Exception((int) error);
            }

            return requestPacket;
        }

        public static void SetConfig(IEnumerable<ScreenPath> paths, IEnumerable<ScreenMode> modes)
        {
            SetDisplayConfig(paths, modes, SetDisplayConfigFlags.Apply | SetDisplayConfigFlags.UseSuppliedDisplayConfig | SetDisplayConfigFlags.AllowChanges, true);
        }

        public static Win32Status TestConfig(IEnumerable<ScreenPath> paths, IEnumerable<ScreenMode> modes)
        {
            return SetDisplayConfig(paths, modes, SetDisplayConfigFlags.Validate | SetDisplayConfigFlags.UseSuppliedDisplayConfig | SetDisplayConfigFlags.AllowChanges, false);
        }

        internal static ModeInfo UpdateModeInfo(ModeInfo modeInfo, Monitor monitor)
        {
            return modeInfo.infoType switch
            {
                ModeInfoType.Source => UpdateSourceModeInfo(modeInfo, monitor),
                ModeInfoType.Target => UpdateTargetModeInfo(modeInfo, monitor),
                ModeInfoType.DesktopImage => throw new NotSupportedException(),
                ModeInfoType.None => throw new NotSupportedException(),
                _ => throw new NotSupportedException()
            };
        }

        private static uint GetFrequency(TargetScreenMode targetMode)
        {
            return targetMode == null ? 0 : targetMode.VerticalSyncFrequency.Numerator;
        }

        private static (bool isPrimary, Resolution resolution, Point point) GetSourceModeInformation(SourceScreenMode sourceMode)
        {
            if (sourceMode == null)
            {
                return (false, Resolution.Empty, Point.Empty);
            }

            var isPrimary = Equals(sourceMode.Position, new Point { X = 0, Y = 0 });
            var currentResolution = new Resolution
            {
                Width = sourceMode.Width,
                Height = sourceMode.Height
            };

            return (isPrimary, currentResolution, sourceMode.Position);
        }

        private static Win32Status SetDisplayConfig(IEnumerable<ScreenPath> paths, IEnumerable<ScreenMode> modes, SetDisplayConfigFlags configFlags, bool throwException)
        {
            var win32Paths = paths.Select(path => (PathInfo) path).ToArray();
            var win32Modes = modes.Select(ModeInfoFactory.Create).ToArray();

            var result = DisplayConfigApi.SetDisplayConfig((uint) win32Paths.Length, win32Paths.ToArray(), (uint) win32Modes.Length, win32Modes.ToArray(),
                                                           configFlags);
            return (result != Win32Status.ErrorSuccess) & throwException ? throw new Win32Exception((int) result) : result;
        }

        private static ModeInfo UpdateSourceModeInfo(ModeInfo modeInfo, Monitor monitor)
        {
            (modeInfo.sourceMode.width, modeInfo.sourceMode.height, _) = monitor.CurrentResolution;
            modeInfo.sourceMode.pixelFormat = PixelFormat.PixelFormat32Bpp;
            modeInfo.sourceMode.position = PointL.FromPoint(monitor.Position);
            if (monitor.IsPrimary)
            {
                modeInfo.sourceMode.position = new PointL();
            }

            return modeInfo;
        }

        private static ModeInfo UpdateTargetModeInfo(ModeInfo modeInfo, Monitor monitor)
        {
            modeInfo.targetMode.targetVideoSignalInfo.vSyncFreq.Numerator = monitor.CurrentResolution.Frequency;
            return modeInfo;
        }
    }
}