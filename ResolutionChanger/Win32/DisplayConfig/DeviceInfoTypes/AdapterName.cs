using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes
{
    /// <summary>
    ///     The DISPLAYCONFIG_ADAPTER_NAME structure contains information about the display adapter.
    ///     DISPLAYCONFIG_ADAPTER_NAME structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AdapterName
    {
        /// <summary>
        ///     A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the adapter name. The
        ///     caller should set the <see cref="DeviceInfoHeader.type" /> member of <see cref="DeviceInfoHeader" /> to
        ///     <see cref="DeviceInfoType.GetAdapterName" /> and the <see cref="DeviceInfoHeader.adapterId" /> member of
        ///     <see cref="DeviceInfoHeader"/> to the adapter identifier of the adapter for which the caller wants the name. For this
        ///     request, the caller does not need to set the <see cref="DeviceInfoHeader.id" /> member of
        ///     <see cref="DeviceInfoHeader" />. The caller should set the <see cref="DeviceInfoHeader.size" /> member of
        ///     <see cref="DeviceInfoHeader" /> to at least the size of the <see cref="AdapterName" /> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public DeviceInfoHeader header;

        /// <summary>
        ///     A <c>null</c>-terminated WCHAR string that is the device name for the adapter. This name can be used with
        ///     SetupAPI.dll to obtain the device name that is contained in the installation package.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string adapterDevicePath;
    }
}