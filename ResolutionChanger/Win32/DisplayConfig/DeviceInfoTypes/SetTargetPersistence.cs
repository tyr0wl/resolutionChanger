using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure contains information about setting the display.
    ///     DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SetTargetPersistence
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information for setting the target persistence. The
        ///     <see cref="DeviceInfoHeader.type" /> member of <see cref="DeviceInfoHeader" /> is set to
        ///     <see cref="DeviceInfoType.GetTargetPreferredMode" />. <see cref="DeviceInfoHeader" /> also contains the adapter and
        ///     target identifiers of the target to set the persistence for. The <see cref="DeviceInfoHeader.size" /> member of
        ///     <see cref="DeviceInfoHeader" /> is set to at least the size of the <see cref="SetTargetPersistence" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     A UINT32 value that specifies whether the <see cref="DisplayConfigApi.SetDisplayConfig" /> function should enable
        ///     or disable boot persistence for the specified target.
        ///     Setting this member is equivalent to setting the first bit of the 32-bit value member (0x00000001).
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] private readonly uint bootPersistenceOn;

        public bool BootPersistence => bootPersistenceOn > 0;
    }
}