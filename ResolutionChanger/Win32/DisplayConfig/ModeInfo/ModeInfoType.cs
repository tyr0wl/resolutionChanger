namespace ResolutionChanger.Win32.DisplayConfig.ModeInfo
{
    /// <summary>
    ///     The DISPLAYCONFIG_MODE_INFO_TYPE enumeration specifies that the information that is contained within the
    ///     DISPLAYCONFIG_MODE_INFO structure is either source or target mode.
    ///     DISPLAYCONFIG_MODE_INFO_TYPE enumeration (wingdi.h)
    /// </summary>
    public enum ModeInfoType : uint
    {
        None = 0,

        /// <summary>
        ///     Indicates that the <see cref="ModeInfo" /> structure contains source mode information.
        ///     DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE
        /// </summary>
        Source = 1,

        /// <summary>
        ///     Indicates that the <see cref="ModeInfo" /> structure contains target mode information.
        ///     DISPLAYCONFIG_MODE_INFO_TYPE_TARGET
        /// </summary>
        Target = 2,

        /// <summary>
        ///     Indicates that the <see cref="ModeInfo" /> structure contains a valid <see cref="DesktopImageInfo" />
        ///     structure (member: <see cref="ModeInfo.desktopImageInfo" />.
        ///     Supported starting in Windows 10.
        ///     DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE
        /// </summary>
        DesktopImage = 3,
    }
}