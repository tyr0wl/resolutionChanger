using System;

namespace ResolutionChanger.Unmanaged.DisplaySettings
{
    /// <summary>
    ///     Corresponds to DWORD parameter dwFlags of the <see cref="DisplaySettingsApi.ChangeDisplaySettingsEx"/> function (winuser.h)
    /// </summary>
    [Flags]
    public enum ChangeDisplaySettingsFlags : uint
    {
        /// <summary>
        ///     The graphics mode for the current screen will be changed dynamically.
        ///     CDS_NONE
        /// </summary>
        CDS_NONE = 0,

        /// <summary>
        /// 	The graphics mode for the current screen will be changed dynamically and the graphics mode will be updated in the registry.
        ///     The mode information is stored in the USER profile.
        ///     CDS_UPDATEREGISTRY
        /// </summary>
        CDS_UPDATEREGISTRY = 0x00000001,

        /// <summary>
        ///     The system tests if the requested graphics mode could be set.
        ///     CDS_TEST
        /// </summary>
        CDS_TEST = 0x00000002,

        /// <summary>
        ///     The mode is temporary in nature.
        ///     If you change to and from another desktop, this mode will not be reset.
        ///     CDS_FULLSCREEN
        /// </summary>
        CDS_FULLSCREEN = 0x00000004,

        /// <summary>
        ///	    The settings will be saved in the global settings area so that they will affect all users on the machine.
        ///     Otherwise, only the settings for the user are modified.
        ///     This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
        ///     CDS_GLOBAL
        /// </summary>
        CDS_GLOBAL = 0x00000008,

        /// <summary>
        ///     This device will become the primary device.
        ///     CDS_SET_PRIMARY
        /// </summary>
        CDS_SET_PRIMARY = 0x00000010,

        /// <summary>
        ///     When set, the lParam parameter is a pointer to a VIDEOPARAMETERS structure.
        ///     CDS_VIDEOPARAMETERS
        /// </summary>
        CDS_VIDEOPARAMETERS = 0x00000020,

        /// <summary>
        /// 	Enables settings changes to unsafe graphics modes.
        ///     CDS_ENABLE_UNSAFE_MODES
        /// </summary>
        CDS_ENABLE_UNSAFE_MODES = 0x00000100,

        /// <summary>
        /// 	Disables settings changes to unsafe graphics modes.
        ///     CDS_DISABLE_UNSAFE_MODES
        /// </summary>
        CDS_DISABLE_UNSAFE_MODES = 0x00000200,

        /// <summary>
        ///     The settings should be changed, even if the requested settings are the same as the current settings.
        ///     CDS_RESET
        /// </summary>
        CDS_RESET = 0x40000000,

        /// <summary>
        ///     undocumented
        ///     CDS_RESET_EX
        /// </summary>
        CDS_RESET_EX = 0x20000000,

        /// <summary>
        ///     The settings will be saved in the registry, but will not take effect.
        ///     This flag is only valid when specified with the CDS_UPDATEREGISTRY flag.
        ///     CDS_NORESET
        /// </summary>
        CDS_NORESET = 0x10000000,
    }
}