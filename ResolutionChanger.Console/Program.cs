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
                    });
                    displayDevice.cb = Marshal.SizeOf(displayDevice);
                }
            }
            catch (Exception ex)
            {
                SystemConsole.WriteLine(ex);
            }
        }
    }
}