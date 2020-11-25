namespace ResolutionChanger.Win32.DisplayConfig.Paths
{
    /// <summary>
    ///     The DISPLAYCONFIG_ROTATION enumeration specifies the clockwise rotation of the display.
    ///     DISPLAYCONFIG_ROTATION enumeration (wingdi.h)
    /// </summary>
    public enum Rotation : uint
    {
        /// <summary>
        ///     Invalid according to the documentation.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Indicates that rotation is 0 degrees—landscape mode.
        ///     DISPLAYCONFIG_ROTATION_IDENTITY
        /// </summary>
        Identity = 1,

        /// <summary>
        ///     Indicates that rotation is 90 degrees clockwise—portrait mode.
        ///     DISPLAYCONFIG_ROTATION_ROTATE90
        /// </summary>
        Rotate90 = 2,

        /// <summary>
        ///     Indicates that rotation is 180 degrees clockwise—inverted landscape mode.
        ///     DISPLAYCONFIG_ROTATION_ROTATE180
        /// </summary>
        Rotate180 = 3,

        /// <summary>
        ///     Indicates that rotation is 270 degrees clockwise—inverted portrait mode.
        ///     DISPLAYCONFIG_ROTATION_ROTATE270
        /// </summary>
        Rotate270 = 4,
    }
}