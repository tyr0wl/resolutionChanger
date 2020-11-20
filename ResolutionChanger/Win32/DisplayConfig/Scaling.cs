namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_SCALING enumeration specifies the scaling transformation applied to content displayed on a video
    ///     present network (VidPN) present path.
    ///     DISPLAYCONFIG_SCALING enumeration (wingdi.h)
    /// </summary>
    public enum Scaling : uint
    {
        /// <summary>
        ///     Indicates the identity transformation; the source content is presented with no change. This transformation is
        ///     available only if the path's source mode has the same spatial resolution as the path's target mode.
        ///     DISPLAYCONFIG_SCALING_IDENTITY
        /// </summary>
        Identity = 1,

        /// <summary>
        ///     Indicates the centering transformation; the source content is presented unscaled, centered with respect to the
        ///     spatial resolution of the target mode.
        ///     DISPLAYCONFIG_SCALING_CENTERED
        /// </summary>
        Centered = 2,

        /// <summary>
        ///     Indicates the content is scaled to fit the path's target.
        ///     DISPLAYCONFIG_SCALING_STRETCHED
        /// </summary>
        Stretched = 3,

        /// <summary>
        ///     Indicates the aspect-ratio centering transformation.
        ///     DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX
        /// </summary>
        AspectRatioCenteredMax = 4,

        /// <summary>
        ///     Indicates that the caller requests a custom scaling that the caller cannot describe with any of the other
        ///     DISPLAYCONFIG_SCALING_XXX values. Only a hardware vendor's value-add application should use <see cref="Custom" />,
        ///     because the value-add application might require a private interface to the driver. The application can then use
        ///     <see cref="Custom" /> to indicate additional context for the driver for the custom value on the specified path.
        ///     DISPLAYCONFIG_SCALING_CUSTOM
        /// </summary>
        Custom = 5,

        /// <summary>
        ///     Indicates that the caller does not have any preference for the scaling. The
        ///     <see cref="DisplayConfigApi.SetDisplayConfig" /> function will use the scaling value that was last saved in the
        ///     database for the path. If such a scaling value does not exist, <see cref="DisplayConfigApi.SetDisplayConfig" />
        ///     will use the default scaling for the computer. For example, <see cref="Stretched" /> for tablet computers and
        ///     <see cref="AspectRatioCenteredMax" /> for non-tablet computers.
        ///     DISPLAYCONFIG_SCALING_PREFERRED
        /// </summary>
        Preferred = 128,

        /// <summary>
        ///     Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this
        ///     enumeration to compile to a size other than 32 bits. You should not use this value.
        ///     DISPLAYCONFIG_SCALING_FORCE_UINT32
        /// </summary>
        ForceUint32 = 0xFFFFFFFF
    }
}