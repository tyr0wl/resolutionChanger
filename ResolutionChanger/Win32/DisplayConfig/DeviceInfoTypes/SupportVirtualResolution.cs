using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION structure contains information on the state of virtual resolution support for the monitor.
    ///     DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SupportVirtualResolution
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that holds information on the type, size, adapterID, and ID of the target the monitor is connected to.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     Setting this bit disables virtual mode for the monitor using information found in <see cref="header"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] private readonly uint disableMonitorVirtualResolution;
    }
}