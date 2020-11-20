using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Specifies base output technology info for a given target ID.
    ///     DISPLAYCONFIG_TARGET_BASE_TYPE structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TargetBaseType
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains info about the request for the target device name. The
        ///     caller should set the <see cref="DeviceInfoHeader.type" /> member of <see cref="DeviceInfoHeader" /> to
        ///     <see cref="DeviceInfoType.GetTargetBaseType" /> and the <see cref="DeviceInfoHeader.adapterId" /> and
        ///     <see cref="DeviceInfoHeader.id" /> members of <see cref="DeviceInfoHeader" /> to the target for which the caller
        ///     wants the target device name.
        ///     The caller should set the <see cref="DeviceInfoHeader.size" /> member of <see cref="DeviceInfoHeader" /> to at
        ///     least the size of the <see cref="TargetBaseType" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     The base output technology, given as a constant value of the <see cref="VideoOutputTechnology" /> enumeration, of
        ///     the adapter and the target specified by the <see cref="header" /> member.
        ///     <br />
        ///     For a Miracast display device, a call to the
        ///     <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetBaseType)" /> function always returns a value of
        ///     <see cref="VideoOutputTechnology.Miracast" />, regardless of what the Miracast sink reports as the connector type.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly VideoOutputTechnology baseOutputTechnology;
    }
}