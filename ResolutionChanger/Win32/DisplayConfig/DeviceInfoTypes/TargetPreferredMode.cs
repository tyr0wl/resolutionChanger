using System.Runtime.InteropServices;
using ResolutionChanger.Win32.DisplayConfig.Modes;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_TARGET_PREFERRED_MODE structure contains information about the preferred mode of a display.
    ///     DISPLAYCONFIG_TARGET_PREFERRED_MODE structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct TargetPreferredMode
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the target preferred
        ///     mode. The caller should set the <see cref="DeviceInfoHeader.type" /> member of <see cref="DeviceInfoHeader" /> to
        ///     <see cref="DeviceInfoType.GetTargetPreferredMode" /> and the <see cref="DeviceInfoHeader.adapterId" /> and
        ///     <see cref="DeviceInfoHeader.id" /> members of <see cref="DeviceInfoHeader" /> to the target for which the caller
        ///     wants the preferred mode. The caller should set the <see cref="DeviceInfoHeader.size" /> member of
        ///     <see cref="DeviceInfoHeader" /> to at least the size of the <see cref="TargetPreferredMode" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     The width in pixels of the best mode for the monitor that is connected to the target that the
        ///     <see cref="TargetMode" /> member specifies.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly uint width;

        /// <summary>
        ///     The height in pixels of the best mode for the monitor that is connected to the target that the
        ///     <see cref="TargetMode" /> member specifies.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly uint height;

        /// <summary>
        ///     A DISPLAYCONFIG_TARGET_MODE structure that describes the best target mode for the monitor that is connected to the
        ///     specified target.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public TargetMode targetMode;
    }
}