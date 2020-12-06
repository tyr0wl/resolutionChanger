namespace ResolutionChanger.Win32.DisplaySettings
{
    /// <summary>
    ///     Represents the possible return values of the <see cref="DisplaySettingsApi.ChangeDisplaySettingsEx"/> function (winuser.h)
    /// </summary>
    internal enum DisplayChange
    {
        /// <summary>
        ///     The settings change was successful.
        ///     DISP_CHANGE_SUCCESSFUL 
        /// </summary>
        Successful = 0,

        /// <summary>
        ///     The computer must be restarted for the graphics mode to work.
        ///     DISP_CHANGE_RESTART
        /// </summary>
        Restart = 1,

        /// <summary>
        ///     The display driver failed the specified graphics mode.
        ///     DISP_CHANGE_FAILED
        /// </summary>
        Failed = -1,

        /// <summary>
        ///     The graphics mode is not supported.
        ///     DISP_CHANGE_BADMODE
        /// </summary>
        BadMode = -2,

        /// <summary>
        ///     Unable to write settings to the registry.
        ///     DISP_CHANGE_NOTUPDATED
        /// </summary>
        NotUpdated = -3,

        /// <summary>
        ///     An invalid set of flags was passed in.
        ///     DISP_CHANGE_BADFLAGS
        /// </summary>
        BadFlags = -4,

        /// <summary>
        ///     An invalid parameter was passed in. This can include an invalid flag or combination of flags.
        ///     DISP_CHANGE_BADPARAM
        /// </summary>
        BadParam = -5,

        /// <summary>
        ///     The settings change was unsuccessful because the system is DualView capable.
        ///     DISP_CHANGE_BADDUALVIEW
        /// </summary>
        BadDualView = -6
    }
}