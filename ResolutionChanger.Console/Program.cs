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
                        SystemConsole.WriteLine($"{id}, {displayDevice.DeviceName}, {displayDevice.DeviceString}, {displayDevice.StateFlags}, {displayDevice.DeviceID}, {displayDevice.DeviceKey}");
                        displayDevice.cb = Marshal.SizeOf(displayDevice);
                        User32.EnumDisplayDevices(displayDevice.DeviceName, 0, ref displayDevice, 0);
                        SystemConsole.WriteLine($"{displayDevice.DeviceName}, {displayDevice.DeviceString}");
                    }

                    monitors.Add(new Monitor
                    {
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
        }
    }
}