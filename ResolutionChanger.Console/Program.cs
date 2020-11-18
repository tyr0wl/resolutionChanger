using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ResolutionChanger.Unmanaged;
using SystemConsole = System.Console;

namespace ResolutionChanger.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var monitors = new List<Monitor>();

            var displayDevice = new DisplayDevice();
            displayDevice.cb = Marshal.SizeOf(displayDevice);
            try
            {
                // User32.EnumDisplayDevices only fills displayDevice with the settings for the provided iDevNum.
                // In order to get all devices we need to call User32.EnumDisplayDevices with increasing iDevNums until it returns false.
                for (uint id = 0; User32.EnumDisplayDevices(null, id, ref displayDevice, 0); id++)
                {
                    if (displayDevice.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop))
                    {
                        displayDevice.cb = Marshal.SizeOf(displayDevice);
                    }

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

                if (User32.EnumDisplaySettings(monitor.DeviceName, User32.EnumCurrentSettings, ref devMode))
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
                while (User32.EnumDisplaySettings(monitor.DeviceName, modeNum, ref devMode))
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

            var secondMonitor = monitors.First();
            SetAsPrimaryMonitor(secondMonitor);
        }

        public static void Update(Monitor monitor)
        {
            var deviceMode = new DevMode();

            User32.EnumDisplaySettings(monitor.DeviceName, User32.EnumCurrentSettings, ref deviceMode);

            deviceMode.dmDisplayFrequency = monitor.CurrentResolution.Frequency;
            deviceMode.dmPosition.x = monitor.Position.X;
            deviceMode.dmPosition.y = monitor.Position.Y;

            User32.ChangeDisplaySettingsEx(
                monitor.DeviceName,
                ref deviceMode,
                (IntPtr)null,
                (ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | ChangeDisplaySettingsFlags.CDS_NORESET),
                IntPtr.Zero);
            User32.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr)null, ChangeDisplaySettingsFlags.CDS_NONE, (IntPtr)null);
        }

        public static void SetAsPrimaryMonitor(Monitor monitor)
        {
            var device = new DisplayDevice();
            var deviceMode = new DevMode();
            device.cb = Marshal.SizeOf(device);

            User32.EnumDisplaySettings(monitor.DeviceName, User32.EnumCurrentSettings, ref deviceMode);
            var offsetX = deviceMode.dmPosition.x;
            var offsetY = deviceMode.dmPosition.y;
            deviceMode.dmPosition.x = 0;
            deviceMode.dmPosition.y = 0;

            User32.ChangeDisplaySettingsEx(
                monitor.DeviceName,
                ref deviceMode,
                (IntPtr)null,
                (ChangeDisplaySettingsFlags.CDS_SET_PRIMARY | ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | ChangeDisplaySettingsFlags.CDS_NORESET),
                IntPtr.Zero);

            device = new DisplayDevice();
            device.cb = Marshal.SizeOf(device);

            // Update remaining devices
            for (uint otherId = 0; User32.EnumDisplayDevices(null, otherId, ref device, 0); otherId++)
            {
                if (device.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop) && otherId != monitor.Id)
                {
                    device.cb = Marshal.SizeOf(device);
                    var otherDeviceMode = new DevMode();

                    User32.EnumDisplaySettings(device.DeviceName, User32.EnumCurrentSettings, ref otherDeviceMode);

                    otherDeviceMode.dmPosition.x -= offsetX;
                    otherDeviceMode.dmPosition.y -= offsetY;

                    User32.ChangeDisplaySettingsEx(
                        device.DeviceName,
                        ref otherDeviceMode,
                        (IntPtr)null,
                        (ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | ChangeDisplaySettingsFlags.CDS_NORESET),
                        IntPtr.Zero);

                }

                device.cb = Marshal.SizeOf(device);
            }

            // Apply settings
            User32.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr)null, ChangeDisplaySettingsFlags.CDS_NONE, (IntPtr)null);
        }
    }
}