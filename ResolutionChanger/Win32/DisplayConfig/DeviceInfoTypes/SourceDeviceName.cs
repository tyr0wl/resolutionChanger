using System.Runtime.InteropServices;
using ResolutionChanger.Win32.DisplaySettings;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_SOURCE_DEVICE_NAME structure contains the GDI device name for the source or view.
    ///     DISPLAYCONFIG_SOURCE_DEVICE_NAME structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct SourceDeviceName
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the source device
        ///     name. The caller should set the <see cref="DeviceInfoHeader.type" /> member of <see cref="DeviceInfoHeader" /> to
        ///     <see cref="DeviceInfoType.GetSourceName" /> and the <see cref="DeviceInfoHeader.adapterId" /> and
        ///     <see cref="DeviceInfoHeader.id" /> members of <see cref="DeviceInfoHeader" /> to the source for which the caller
        ///     wants the source device name. The caller should set the <see cref="DeviceInfoHeader.size" /> member of
        ///     <see cref="DeviceInfoHeader" /> to at least the size of the <see cref="SourceDeviceName" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     A <c>null</c>-terminated WCHAR string that is the GDI device name for the source, or view. This name can be used in
        ///     a call to <see cref="DisplaySettingsApi.EnumDisplaySettings" /> to obtain a list of available modes for the
        ///     specified source.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string viewGdiDeviceName;

        public override string ToString()
        {
            return $"{GetType().Name}: {viewGdiDeviceName}";
        }
    }
}