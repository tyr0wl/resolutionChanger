using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplaySettings
{
    /// <summary>
    ///     The DISPLAY_DEVICE structure receives information about the display device specified by the iDevNum parameter of the <see cref="DisplaySettingsApi.EnumDisplayDevices"/> function (wingdi.h).
    ///     DISPLAY_DEVICE
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct DisplayDevice
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }
}