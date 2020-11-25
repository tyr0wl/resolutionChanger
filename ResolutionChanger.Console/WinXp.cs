using System;
using System.Runtime.InteropServices;
using ResolutionChanger.Win32;
using ResolutionChanger.Win32.DisplaySettings;

namespace ResolutionChanger.Console
{
    internal class WinXp
    {
        public static void Deactivate(Monitor monitor)
        {
            var deleteScreenMode = new DevMode
            {
                dmDriverExtra = 0,
                dmFields = DmFieldFlags.Position | DmFieldFlags.PelsHeight | DmFieldFlags.PelsWidth,
                dmPelsWidth = 0,
                dmPelsHeight = 0,
                dmPosition = new PointL()
            };

            deleteScreenMode.dmSize = (short) Marshal.SizeOf(deleteScreenMode);

            var result = DisplaySettingsApi.ChangeDisplaySettingsEx(monitor.DevicePath, ref deleteScreenMode, IntPtr.Zero, ChangeDisplaySettingsFlags.UpdateRegistry, IntPtr.Zero);
            if (result == DisplayChange.Successful)
            {
                DisplaySettingsApi.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr) null, ChangeDisplaySettingsFlags.None, (IntPtr) null);
            }
        }

        public static void SetAsPrimaryMonitor(Monitor monitor)
        {
            var deviceMode = new DevMode { dmSize = (short) Marshal.SizeOf(typeof(DevMode)) };
            DisplaySettingsApi.EnumDisplaySettings(monitor.DevicePath, DisplaySettingsApi.CurrentSettings, ref deviceMode);
            var offsetX = deviceMode.dmPosition.x;
            var offsetY = deviceMode.dmPosition.y;
            deviceMode.dmPosition.x = 0;
            deviceMode.dmPosition.y = 0;

            var result = DisplaySettingsApi.ChangeDisplaySettingsEx(
                monitor.DevicePath,
                ref deviceMode,
                (IntPtr) null,
                ChangeDisplaySettingsFlags.SetPrimary | ChangeDisplaySettingsFlags.UpdateRegistry | ChangeDisplaySettingsFlags.NoReset,
                IntPtr.Zero);

            if (result != DisplayChange.Successful)
            {
                return;
            }

            var device = new DisplayDevice();
            device.cb = Marshal.SizeOf(device);

            // Update remaining devices
            for (uint otherId = 0; DisplaySettingsApi.EnumDisplayDevices(null, otherId, ref device, 0); otherId++)
            {
                if (device.StateFlags.HasFlag(DisplayDeviceStateFlags.AttachedToDesktop) && otherId != monitor.TargetId)
                {
                    device.cb = Marshal.SizeOf(device);
                    var otherDeviceMode = new DevMode();

                    DisplaySettingsApi.EnumDisplaySettings(device.DeviceName, DisplaySettingsApi.CurrentSettings, ref otherDeviceMode);

                    otherDeviceMode.dmPosition.x -= offsetX;
                    otherDeviceMode.dmPosition.y -= offsetY;

                    result = DisplaySettingsApi.ChangeDisplaySettingsEx(
                        device.DeviceName,
                        ref otherDeviceMode,
                        (IntPtr) null,
                        ChangeDisplaySettingsFlags.UpdateRegistry | ChangeDisplaySettingsFlags.NoReset,
                        IntPtr.Zero);

                    if (result != DisplayChange.Successful)
                    {
                        return;
                    }
                }

                device.cb = Marshal.SizeOf(device);
            }

            // Apply settings
            DisplaySettingsApi.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr) null, ChangeDisplaySettingsFlags.None, (IntPtr) null);
        }

        public static void Update(Monitor monitor)
        {
            if (monitor.IsActive == false)
            {
                Deactivate(monitor);
                return;
            }

            var deviceMode = new DevMode { dmSize = (short) Marshal.SizeOf(typeof(DevMode)) };
            DisplaySettingsApi.EnumDisplaySettings(monitor.DevicePath, DisplaySettingsApi.CurrentSettings, ref deviceMode);

            deviceMode.dmPelsWidth = (int) monitor.CurrentResolution.Width;
            deviceMode.dmPelsHeight = (int) monitor.CurrentResolution.Height;
            deviceMode.dmDisplayFrequency = (int) monitor.CurrentResolution.Frequency;
            deviceMode.dmPosition.x = monitor.Position.X;
            deviceMode.dmPosition.y = monitor.Position.Y;

            var changeFlags = ChangeDisplaySettingsFlags.UpdateRegistry | ChangeDisplaySettingsFlags.NoReset;
            if (monitor.IsPrimary)
            {
                changeFlags |= ChangeDisplaySettingsFlags.SetPrimary;
            }

            var result = DisplaySettingsApi.ChangeDisplaySettingsEx(
                monitor.DevicePath,
                ref deviceMode,
                (IntPtr) null,
                changeFlags,
                IntPtr.Zero);

            if (result == DisplayChange.Successful)
            {
                System.Console.WriteLine($"Update success {monitor.DisplayName}");
                result = DisplaySettingsApi.ChangeDisplaySettingsEx(null, IntPtr.Zero, (IntPtr) null, ChangeDisplaySettingsFlags.None, (IntPtr) null);
            }
            else
            {
                System.Console.WriteLine($"Update not successful {monitor.DisplayName}");
            }
        }
    }
}