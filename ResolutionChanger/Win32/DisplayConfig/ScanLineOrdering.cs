namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_SCANLINE_ORDERING enumeration specifies the method that the display uses to create an image on a
    ///     screen.
    ///     DISPLAYCONFIG_SCANLINE_ORDERING enumeration (wingdi.h)
    /// </summary>
    public enum ScanLineOrdering : uint
    {
        /// <summary>
        ///     Indicates that scan-line ordering of the output is unspecified. The caller can only set the
        ///     <see cref="PathTargetInfo.scanLineOrdering" /> member of the
        ///     <see cref="PathTargetInfo" /> structure in a call to the
        ///     <see cref="DisplayConfigApi.SetDisplayConfig" /> function to
        ///     <see cref="DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED" /> if the caller also set the refresh rate
        ///     <see cref="Rational.Denominator" /> and <see cref="Rational.Numerator" /> of the
        ///     <see cref="PathTargetInfo.refreshRate" /> member both to zero. In this case,
        ///     <see cref="DisplayConfigApi.SetDisplayConfig" /> uses the best refresh rate it can find.
        ///     DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED
        /// </summary>
        Unspecified = 0,

        /// <summary>
        ///     Indicates that the output is a progressive image.
        ///     DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE
        /// </summary>
        Progressive = 1,

        /// <summary>
        ///     Indicates that the output is an interlaced image that is created beginning with the upper field.
        ///     DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED
        /// </summary>
        Interlaced = 2,

        /// <summary>
        ///     Indicates that the output is an interlaced image that is created beginning with the upper field.
        ///     DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST
        /// </summary>
        InterlacedUpperFieldFirst = Interlaced,

        /// <summary>
        ///     Indicates that the output is an interlaced image that is created beginning with the lower field.
        ///     DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST
        /// </summary>
        InterlacedLowerFieldFirst = 3,
    }
}