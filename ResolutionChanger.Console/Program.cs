using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using ResolutionChanger.Win32;
using ResolutionChanger.Win32.DisplayConfig;
using ResolutionChanger.Win32.DisplaySettings;
using SystemConsole = System.Console;

namespace ResolutionChanger.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var friendlyNames = GetAllMonitorsFriendlyNames().ToList();
            var monitors = new List<Monitor>();

            var displayDevice = new DisplayDevice();
            displayDevice.cb = Marshal.SizeOf(displayDevice);
            try
            {
                // User32.EnumDisplayDevices only fills displayDevice with the settings for the provided iDevNum.
                // In order to get all devices we need to call User32.EnumDisplayDevices with increasing iDevNums until it returns false.
                for (uint id = 0; DisplaySettingsApi.EnumDisplayDevices(null, id, ref displayDevice, 0); id++)
                {
                    monitors.Add(new Monitor
                    {
                        Id = id,
                        DeviceName = displayDevice.DeviceName,
                        IsPrimary = displayDevice.StateFlags.HasFlag(DisplayDeviceStateFlags.PrimaryDevice),
                        IsActive = displayDevice.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop),
                    });
                    displayDevice.cb = Marshal.SizeOf(displayDevice);
                }
            }
            catch (Exception ex)
            {
                SystemConsole.WriteLine(ex);
            }

            foreach (var monitor in monitors)
            {
                var devMode = new DevMode();
                devMode.dmSize = (short)Marshal.SizeOf(devMode);

                if (DisplaySettingsApi.EnumDisplaySettings(monitor.DeviceName, DisplaySettingsApi.CurrentSettings, ref devMode))
                {
                    monitor.CurrentResolution = new Resolution
                    {
                        Width = devMode.dmPelsWidth,
                        Height = devMode.dmPelsHeight,
                        Frequency = devMode.dmDisplayFrequency,
                    };
                }

                monitor.Position = new Point
                {
                    X = devMode.dmPosition.x,
                    Y = devMode.dmPosition.y
                };

                // User32.EnumDisplaySettings only fills devMode with the settings for the provided modeNum.
                // In order to get all supported resolutions for a monitor we need to call User32.EnumDisplaySettings with increasing modeNums until it returns false.
                var modeNum = 0;
                while (DisplaySettingsApi.EnumDisplaySettings(monitor.DeviceName, modeNum, ref devMode))
                {
                    modeNum++;
                    monitor.SupportedResolutions.Add(new Resolution
                    {
                        Width = devMode.dmPelsWidth,
                        Height = devMode.dmPelsHeight,
                        Frequency = devMode.dmDisplayFrequency,
                    });
                }

                SystemConsole.WriteLine(monitor);
            }

            var primaryMonitor = monitors.First(monitor => monitor.IsPrimary);
            var secondMonitor = monitors.Skip(1).First();
            //secondMonitor.CurrentResolution = new Resolution
            //{
            //    Width = secondMonitor.CurrentResolution.Width,
            //    Height = secondMonitor.CurrentResolution.Height,
            //    Frequency = 120,
            //};
            //secondMonitor.Position = new Point { X = -1920, Y = 1440 - 1080 };
            //secondMonitor.IsActive = false;
            //Update(secondMonitor);

            secondMonitor.IsActive = false;
            secondMonitor.CurrentResolution = new Resolution { Width = 1920, Height = 1080, Frequency = 120 };
            secondMonitor.Position = new Point { X = -secondMonitor.CurrentResolution.Width, Y = primaryMonitor.Position.Y - secondMonitor.Position.Y };
            //Update(secondMonitor);

            //SetAsPrimaryMonitor(secondMonitor);
            //Deactivate(secondMonitor);
        }

        public static void Update(Monitor monitor)
        {
            if (monitor.IsActive == false)
            {
                Deactivate(monitor);
                return;
            }

            var deviceMode = new DevMode();

            DisplaySettingsApi.EnumDisplaySettings(monitor.DeviceName, DisplaySettingsApi.CurrentSettings, ref deviceMode);

            deviceMode.dmPelsWidth = monitor.CurrentResolution.Width;
            deviceMode.dmPelsHeight = monitor.CurrentResolution.Height;
            deviceMode.dmDisplayFrequency = monitor.CurrentResolution.Frequency;
            deviceMode.dmPosition.x = monitor.Position.X;
            deviceMode.dmPosition.y = monitor.Position.Y;

            var result = DisplaySettingsApi.ChangeDisplaySettingsEx(
                monitor.DeviceName,
                ref deviceMode,
                (IntPtr)null,
                (ChangeDisplaySettingsFlags.UpdateRegistry | ChangeDisplaySettingsFlags.NoReset),
                IntPtr.Zero);

            if (result == DisplayChange.Successful)
            {
                DisplaySettingsApi.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr)null, ChangeDisplaySettingsFlags.None, (IntPtr)null);
            }
        }

        public static void Deactivate(Monitor monitor)
        {
            var deleteScreenMode = new DevMode
            {
                dmDriverExtra = 0,
                dmFields = DmFieldFlags.Position | DmFieldFlags.PelsHeight | DmFieldFlags.PelsWidth,
                dmPelsWidth = 0,
                dmPelsHeight = 0,
                dmPosition = new PointL(),
            };

            deleteScreenMode.dmSize = (short)Marshal.SizeOf(deleteScreenMode); 
            
            var result = DisplaySettingsApi.ChangeDisplaySettingsEx(monitor.DeviceName, ref deleteScreenMode, IntPtr.Zero, ChangeDisplaySettingsFlags.UpdateRegistry, IntPtr.Zero);
            if (result == DisplayChange.Successful)
            {
                DisplaySettingsApi.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr)null, ChangeDisplaySettingsFlags.None, (IntPtr)null);
            }
        }

        public static void SetAsPrimaryMonitor(Monitor monitor)
        {
            var device = new DisplayDevice();
            var deviceMode = new DevMode();
            device.cb = Marshal.SizeOf(device);

            DisplaySettingsApi.EnumDisplaySettings(monitor.DeviceName, DisplaySettingsApi.CurrentSettings, ref deviceMode);
            var offsetX = deviceMode.dmPosition.x;
            var offsetY = deviceMode.dmPosition.y;
            deviceMode.dmPosition.x = 0;
            deviceMode.dmPosition.y = 0;

            var result = DisplaySettingsApi.ChangeDisplaySettingsEx(
                monitor.DeviceName,
                ref deviceMode,
                (IntPtr)null,
                (ChangeDisplaySettingsFlags.SetPrimary | ChangeDisplaySettingsFlags.UpdateRegistry | ChangeDisplaySettingsFlags.NoReset),
                IntPtr.Zero);

            if (result != DisplayChange.Successful)
            {
                return;
            }

            device = new DisplayDevice();
            device.cb = Marshal.SizeOf(device);

            // Update remaining devices
            for (uint otherId = 0; DisplaySettingsApi.EnumDisplayDevices(null, otherId, ref device, 0); otherId++)
            {
                if (device.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop) && otherId != monitor.Id)
                {
                    device.cb = Marshal.SizeOf(device);
                    var otherDeviceMode = new DevMode();

                    DisplaySettingsApi.EnumDisplaySettings(device.DeviceName, DisplaySettingsApi.CurrentSettings, ref otherDeviceMode);

                    otherDeviceMode.dmPosition.x -= offsetX;
                    otherDeviceMode.dmPosition.y -= offsetY;

                    result = DisplaySettingsApi.ChangeDisplaySettingsEx(
                        device.DeviceName,
                        ref otherDeviceMode,
                        (IntPtr)null,
                        (ChangeDisplaySettingsFlags.UpdateRegistry | ChangeDisplaySettingsFlags.NoReset),
                        IntPtr.Zero);

                    if (result != DisplayChange.Successful)
                    {
                        return;
                    }
                }

                device.cb = Marshal.SizeOf(device);
            }

            // Apply settings
            DisplaySettingsApi.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr)null, ChangeDisplaySettingsFlags.None, (IntPtr)null);
        }

        private static TargetDeviceName GetTargetDeviceName(LuId adapterId, uint targetId)
        {
            var deviceName = new TargetDeviceName
            {
                header =
                {
                    size = (uint)Marshal.SizeOf(typeof (TargetDeviceName)),
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

        private static IEnumerable<string> GetAllMonitorsFriendlyNames()
        {
            var error = DisplayConfigApi.GetDisplayConfigBufferSizes(QueryDeviceConfigFlags.AllPaths, out var pathCount, out var modeCount);
            if (error != (int)Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            var displayPaths = new PathInfo[pathCount];
            var displayModes = new ModeInfo[modeCount];
            error = DisplayConfigApi.QueryDisplayConfig(QueryDeviceConfigFlags.AllPaths, ref pathCount, displayPaths, ref modeCount, displayModes, IntPtr.Zero);
            
            if (error != (int)Win32Status.ErrorSuccess)
            {
                throw new Win32Exception(error);
            }

            var availableDisplayPaths = displayPaths.Where(displayPath => displayPath.targetInfo.targetAvailable).GroupBy(info => (info.targetInfo.adapterId, info.targetInfo.id));
            foreach (var availableDisplayPath in availableDisplayPaths)
            {
                var (adapterId, id) = availableDisplayPath.Key;
                yield return GetTargetDeviceName(adapterId, id).monitorFriendlyDeviceName;
            }
        }

        /*
         * Gets GDI Device name from Source (e.g. \\.\DISPLAY4).
        */
        public static SourceDeviceName GetGdiDeviceNameFromSource(LuId adapterId, uint sourceId)
        {
            var deviceName = new SourceDeviceName
            {
                header =
                {
                    size = (uint)Marshal.SizeOf(typeof (SourceDeviceName)),
                    adapterId = adapterId,
                    id = sourceId,
                    type = DeviceInfoType.GetSourceName
                }
            };

            DisplayConfigApi.DisplayConfigGetDeviceInfo(ref deviceName);
            return deviceName;
        }

        /*
            Gets Friendly name from Target (e.g. "SyncMaster")
            Gets Device Path from Target
            e.g. \\?\DISPLAY#SAM0304#5&9a89472&0&UID33554704#{e6f07b5f-ee97-4a90-b076-33f57bf4eaa7}
        */
        public TargetDeviceName GetDISPLAYCONFIG_TARGET_DEVICE_NAME(LuId adapterId, uint targetId)
        {
            var deviceName = new TargetDeviceName
            {
                header =
                {
                    size = (uint)Marshal.SizeOf(typeof (TargetDeviceName)),
                    adapterId = adapterId,
                    id = targetId,
                    type = DeviceInfoType.GetTargetName
                }
            };

            DisplayConfigApi.DisplayConfigGetDeviceInfo(ref deviceName);
            return deviceName;
        }
    }
}