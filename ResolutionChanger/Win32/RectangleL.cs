using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32
{
    /// <summary>
    ///     The RECTL structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
    ///     RECTL structure (windef.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct RectangleL
    {
        /// <summary>
        ///     Specifies the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly int left;

        /// <summary>
        ///     Specifies the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly int top;

        /// <summary>
        ///     Specifies the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly int right;

        /// <summary>
        ///     Specifies the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)] public readonly int bottom;
    }
}