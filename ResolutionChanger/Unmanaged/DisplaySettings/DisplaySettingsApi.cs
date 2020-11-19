using System;
using System.Runtime.InteropServices;

namespace ResolutionChanger.Unmanaged.DisplaySettings
{
    public class DisplaySettingsApi
    {
        public const int CurrentSettings = -1;

        public const int RegistrySettings = -2;

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DevMode devMode);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DisplayDevice lpDisplayDevice, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern DisplayChange ChangeDisplaySettingsEx(string lpszDeviceName, ref DevMode lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);

        [DllImport("user32.dll")]
        // A signature for ChangeDisplaySettingsEx with a DevMode struct as the second parameter won't allow you to pass in IntPtr.Zero, so create an overload
        public static extern DisplayChange ChangeDisplaySettingsEx(string lpszDeviceName, IntPtr lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);
    }
}
