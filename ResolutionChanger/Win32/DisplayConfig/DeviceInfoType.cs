using ResolutionChanger.Win32.DisplayConfig.DeviceInfoTypes;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_DEVICE_INFO_TYPE enumeration specifies the type of display device info to configure or obtain
    ///     through the DisplayConfigSetDeviceInfo or <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo" /> function.
    ///     DISPLAYCONFIG_DEVICE_INFO_TYPE enumeration (wingdi.h)
    /// </summary>
    public enum DeviceInfoType : uint
    {
        /// <summary>
        ///     Specifies the source name of the display device. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref SourceDeviceName)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref SourceDeviceName)"/> returns the source name in the <see cref="SourceDeviceName"/> structure.
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME
        /// </summary>
        GetSourceName = 1,

        /// <summary>
        ///     Specifies information about the monitor. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetDeviceName)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetDeviceName)"/> returns info about the monitor in the <see cref="TargetDeviceName"/> structure.
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME
        /// </summary>
        GetTargetName = 2,

        /// <summary>
        ///     Specifies information about the preferred mode of a monitor. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetPreferredMode)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetPreferredMode)"/> returns info about the preferred mode of a monitor in the <see cref="TargetPreferredMode"/> structure.
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE
        /// </summary>
        GetTargetPreferredMode = 3,

        /// <summary>
        ///     Specifies the graphics adapter name. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref AdapterName)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref AdapterName)"/> returns the adapter name in the <see cref="AdapterName"/> structure.
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME
        /// </summary>
        GetAdapterName = 4,

        /// <summary>
        ///     Specifies how to set the monitor. If the <see cref="DisplayConfigApi.DisplayConfigSetDeviceInfo"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigSetDeviceInfo"/> uses info in the <see cref="DeviceInfoTypes.SetTargetPersistence"/> structure to force the output in a boot-persistent manner.
        ///     DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE
        /// </summary>
        SetTargetPersistence = 5,

        /// <summary>
        ///     Specifies how to set the base output technology for a given target ID. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetBaseType)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref TargetBaseType)"/> returns base output technology info in the DISPLAYCONFIG_TARGET_BASE_TYPE structure.
        ///     Supported by WDDM 1.3 and later user-mode display drivers running on Windows 8.1 and later.
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE
        /// </summary>
        GetTargetBaseType = 6,

        /// <summary>
        ///     Specifies the state of virtual mode support. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref SupportVirtualResolution)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref SupportVirtualResolution)"/> returns virtual mode support information in the <see cref="SupportVirtualResolution"/> structure.
        ///     Supported starting in Windows 10.
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_SUPPORT_VIRTUAL_RESOLUTION
        /// </summary>
        GetSupportVirtualResolution = 7,

        /// <summary>
        ///     Specifies how to set the state of virtual mode support. If the <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref SupportVirtualResolution)"/> function is successful, <see cref="DisplayConfigApi.DisplayConfigGetDeviceInfo(ref SupportVirtualResolution)"/> uses info in the <see cref="SupportVirtualResolution"/> structure to change the state of virtual mode support.
        ///     Supported starting in Windows 10.
        ///     DISPLAYCONFIG_DEVICE_INFO_SET_SUPPORT_VIRTUAL_RESOLUTION
        /// </summary>
        SetSupportVirtualResolution = 8,

        /// <summary>
        ///     DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO = 9,

        /// <summary>
        ///     DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE = 10,

        /// <summary>
        ///     DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32
        /// </summary>
        DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32 = 0xFFFFFFFF
    }
}