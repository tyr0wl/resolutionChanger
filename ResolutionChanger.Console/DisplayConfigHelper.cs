using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using ResolutionChanger.Win32;
using ResolutionChanger.Win32.DisplayConfig;
using ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes;

namespace ResolutionChanger.Console
{
    internal class DisplayConfigHelper
    {
        public static ModeInfo CreateSourceModeInfo(Monitor monitor)
        {
            return new()
            {
                adapterId = (LuId) monitor.AdapterId,
                id = monitor.SourceId,
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

        public static ModeInfo CreateTargetModeInfo(Monitor monitor)
        {
            var adapterId = new LuId { LowPart = monitor.AdapterId };
            var preferredMode = GetTargetPreferredMode(adapterId, monitor.TargetId);
            //preferredMode.targetMode.targetVideoSignalInfo.vSyncFreq.Numerator = monitor.CurrentResolution.Frequency;
            return new ModeInfo
            {
                adapterId = adapterId,
                id = monitor.TargetId,
                targetMode = preferredMode.targetMode,
                infoType = ModeInfoType.Target
            };
        }

        public static AdapterName GetAdapterName(LuId adapterId)
        {
            var requestPacket = new AdapterName
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(AdapterName)),
                    adapterId = adapterId,
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

        public static (PathInfo[] paths, ModeInfo[] modes) GetDisplayConfig()
        {
            var error = DisplayConfigApi.GetDisplayConfigBufferSizes(QueryDeviceConfigFlags.AllPaths, out var pathCount, out var modeCount);
            if (error != (int) Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            var paths = new PathInfo[pathCount];
            var modes = new ModeInfo[modeCount];
            error = DisplayConfigApi.QueryDisplayConfig(QueryDeviceConfigFlags.AllPaths, ref pathCount, paths, ref modeCount, modes, IntPtr.Zero);

            if (error != (int) Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            return (paths, modes);
        }

        public static SourceDeviceName GetGdiDeviceNameFromSource(LuId adapterId, uint sourceId)
        {
            var requestPacket = new SourceDeviceName
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(SourceDeviceName)),
                    adapterId = adapterId,
                    id = sourceId,
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

        public static Monitor GetMonitor(PathInfo pathInfo, ModeInfo[] displayModes, TargetDeviceName targetDeviceName)
        {
            var sourceInfo = pathInfo.sourceInfo;
            var sourceMode = SourceMode.Empty;
            if (!sourceInfo.InvalidModeIdx)
            {
                sourceMode = displayModes[sourceInfo.modeInfoIdx].sourceMode;
            }

            var (isPrimary, resolution, point) = GetSourceModeInformation(sourceMode);

            var targetInfo = pathInfo.targetInfo;
            var targetMode = TargetMode.Empty;
            if (!targetInfo.InvalidModeIdx)
            {
                targetMode = displayModes[targetInfo.modeInfoIdx].targetMode;
            }

            resolution.Frequency = GetFrequency(targetMode);

            var monitor = new Monitor
            {
                AdapterId = targetInfo.adapterId.LowPart,
                SourceId = sourceInfo.id,
                TargetId = targetInfo.id,
                DevicePath = targetDeviceName.monitorDevicePath,
                DisplayName = targetDeviceName.monitorFriendlyDeviceName,
                IsActive = pathInfo.flags.HasFlag(PathInfoFlags.Active),
                IsPrimary = isPrimary,
                CurrentResolution = resolution,
                Position = point
            };

            return monitor;
        }

        public static TargetDeviceName GetTargetDeviceName(LuId adapterId, uint targetId)
        {
            var deviceName = new TargetDeviceName
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(TargetDeviceName)),
                    adapterId = adapterId,
                    id = targetId,
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

        public static TargetPreferredMode GetTargetPreferredMode(LuId adapterId, uint id)
        {
            var requestPacket = new TargetPreferredMode
            {
                header =
                {
                    size = (uint) Marshal.SizeOf(typeof(TargetPreferredMode)),
                    adapterId = adapterId,
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

        public static ModeInfo UpdateModeInfo(ModeInfo modeInfo, Monitor monitor)
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

        private static uint GetFrequency(TargetMode targetMode)
        {
            return targetMode.IsEmpty ? 0 : targetMode.targetVideoSignalInfo.vSyncFreq.Numerator;
        }

        private static (bool isPrimary, Resolution resolution, Point point) GetSourceModeInformation(SourceMode sourceMode)
        {
            if (sourceMode.IsEmpty)
            {
                return (false, Resolution.Empty, Point.Empty);
            }

            var isPrimary = Equals(sourceMode.position, new PointL { x = 0, y = 0 });
            var currentResolution = new Resolution
            {
                Width = sourceMode.width,
                Height = sourceMode.height
            };
            var position = new Point
            {
                X = sourceMode.position.x,
                Y = sourceMode.position.y
            };

            return (isPrimary, currentResolution, position);
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