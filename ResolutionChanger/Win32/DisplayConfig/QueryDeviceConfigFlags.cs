namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     Corresponds to UINT32 parameter flags of the <see cref="DisplayConfigApi.GetDisplayConfigBufferSizes"/> function (winuser.h)
    /// </summary>
    public enum QueryDeviceConfigFlags : uint
    {
        None = 0,

        /// <summary>
        ///     The caller requests the table sizes to hold all the possible path combinations.
        ///     QDC_ALL_PATHS
        /// </summary>
        AllPaths = 0x00000001,

        /// <summary>
        ///     The caller requests the table sizes to hold only active paths.
        ///     QDC_ONLY_ACTIVE_PATHS
        /// </summary>
        OnlyActivePaths = 0x00000002,

        /// <summary>
        ///     The caller requests the table sizes to hold the active paths as defined in the persistence database for the currently connected monitors.
        ///     QDC_DATABASE_CURRENT
        /// </summary>
        DatabaseCurrent = 0x00000004
    }
}