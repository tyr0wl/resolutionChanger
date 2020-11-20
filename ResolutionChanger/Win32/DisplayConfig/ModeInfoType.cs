namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_MODE_INFO_TYPE enumeration specifies that the information that is contained within the
    ///     DISPLAYCONFIG_MODE_INFO structure is either source or target mode.
    ///     DISPLAYCONFIG_MODE_INFO_TYPE enumeration (wingdi.h)
    /// </summary>
    public enum ModeInfoType : uint
    {
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
        ///     structure (member: <see cref="ModeInfo.DesktopImageInfo" />. Supported starting in Windows 10.
        ///     DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE
        /// </summary>
        DesktopImage = 3,

        /// <summary>
        ///     Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this
        ///     enumeration to compile to a size other than 32 bits. You should not use this value.
        ///     DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32
        /// </summary>
        ForceUint32 = 0xFFFFFFFF
    }
}