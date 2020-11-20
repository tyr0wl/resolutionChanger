using System;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS structure contains information about a target device.
    ///     DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS structure (wingdi.h)
    /// </summary>
    [Flags]
    public enum TargetDeviceNameFlags : uint
    {
        None = 0,

        /// <summary>
        ///     friendlyNameFromEdid
        /// </summary>
        FriendlyNameFromEdid = 1,

        /// <summary>
        ///     friendlyNameForced
        /// </summary>
        FriendlyNameForced = 2,

        /// <summary>
        ///     edidIdsValid
        /// </summary>
        EdidIdsValid = 4
    }
}