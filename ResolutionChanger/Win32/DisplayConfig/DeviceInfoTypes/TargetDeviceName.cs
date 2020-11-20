using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_TARGET_DEVICE_NAME structure contains information about the target.
    ///     DISPLAYCONFIG_TARGET_DEVICE_NAME structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TargetDeviceName
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the target device
        ///     name. The caller should set the <see cref="DeviceInfoHeader.type" /> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to
        ///     <see cref="DeviceInfoType.TargetName" /> and the <see cref="DeviceInfoHeader.adapterId" /> and
        ///     <see cref="DeviceInfoHeader.id" /> members of DISPLAYCONFIG_DEVICE_INFO_HEADER to the target for which the caller
        ///     wants the target device name. The caller should set the <see cref="DeviceInfoHeader.size" /> member of
        ///     DISPLAYCONFIG_DEVICE_INFO_HEADER to at least the size of the <see cref="TargetDeviceName" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     A DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS structure that identifies, in bit-field flags, information about the
        ///     target.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly TargetDeviceNameFlags flags;

        /// <summary>
        ///     A value from the DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumeration that specifies the target's connector type.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly VideoOutputTechnology outputTechnology;

        /// <summary>
        ///     The manufacture identifier from the monitor extended display identification data (EDID). This member is set only
        ///     when the <see cref="TargetDeviceNameFlags.EdidIdsValid" /> bit-field is set in the
        ///     <see cref="flags" /> member.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)] public readonly ushort edidManufactureId;

        /// <summary>
        ///     The product code from the monitor EDID. This member is set only when the
        ///     <see cref="TargetDeviceNameFlags.EdidIdsValid" /> bit-field is set in the <see cref="flags" /> member.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)] public readonly ushort edidProductCodeId;

        /// <summary>
        ///     The one-based instance number of this particular target only when the adapter has multiple targets of this type.
        ///     The connector instance is a consecutive one-based number that is unique within each adapter. If this is the only
        ///     target of this type on the adapter, this value is zero.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly uint connectorInstance;

        /// <summary>
        ///     A <c>null</c>-terminated WCHAR string that is the device name for the monitor. This name can be used with
        ///     SetupAPI.dll to obtain the device name that is contained in the installation package.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string monitorFriendlyDeviceName;

        /// <summary>
        ///     A <c>null</c>-terminated WCHAR string that is the path to the device name for the monitor. This path can be used
        ///     with SetupAPI.dll to obtain the device name that is contained in the installation package.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string monitorDevicePath;
    }
}