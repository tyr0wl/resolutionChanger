using System.Runtime.InteropServices;

namespace ResolutionChanger.Win32.DisplayConfig
{
    /// <summary>
    ///     The DISPLAYCONFIG_PATH_INFO structure is used to describe a single path from a target to a source.
    ///     DISPLAYCONFIG_PATH_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PathInfo
    {
        /// <summary>
        ///     A DISPLAYCONFIG_PATH_SOURCE_INFO structure that contains the source information for the path.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public readonly PathSourceInfo sourceInfo;

        /// <summary>
        ///     A DISPLAYCONFIG_PATH_TARGET_INFO structure that contains the target information for the path.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public readonly PathTargetInfo targetInfo;

        /// <summary>
        ///     A bitwise OR of flag values that indicates the state of the path.
        /// </summary>
        public PathInfoFlags flags;
    }
}