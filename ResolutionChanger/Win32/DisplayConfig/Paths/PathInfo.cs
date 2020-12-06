using System.Runtime.InteropServices;
using ResolutionChanger.Data.Paths;

namespace ResolutionChanger.Win32.DisplayConfig.Paths
{
    /// <summary>
    ///     The DISPLAYCONFIG_PATH_INFO structure is used to describe a single path from a target to a source.
    ///     DISPLAYCONFIG_PATH_INFO structure (wingdi.h)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct PathInfo
    {
        /// <summary>
        ///     A DISPLAYCONFIG_PATH_SOURCE_INFO structure that contains the source information for the path.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public PathSourceInfo sourceInfo;

        /// <summary>
        ///     A DISPLAYCONFIG_PATH_TARGET_INFO structure that contains the target information for the path.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)] public PathTargetInfo targetInfo;

        /// <summary>
        ///     A bitwise OR of flag values that indicates the state of the path.
        /// </summary>
        public PathInfoFlags flags;

        public override string ToString()
        {
            return $"{{path {sourceInfo},{targetInfo},{flags}}}";
        }

        public static explicit operator PathInfo(ScreenPath screenPath)
        {
            var flags = PathInfoFlags.None;
            if (screenPath.Active)
            {
                flags |= PathInfoFlags.Active;
            }

            if (screenPath.SupportsVirtualMode)
            {
                flags |= PathInfoFlags.SupportVirtualMode;
            }

            return new PathInfo
            {
                sourceInfo = (PathSourceInfo) screenPath.SourcePath,
                targetInfo = (PathTargetInfo) screenPath.TargetPath,
                flags = flags
            };
        }
    }
}