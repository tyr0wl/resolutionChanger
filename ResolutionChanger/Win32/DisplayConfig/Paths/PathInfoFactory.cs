using ResolutionChanger.Data.Paths;

namespace ResolutionChanger.Win32.DisplayConfig.Paths
{
    internal class PathInfoFactory
    {
        public static PathInfo Create(ScreenPath screenPath)
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
                sourceInfo = (PathSourceInfo)screenPath.SourcePath,
                targetInfo = (PathTargetInfo)screenPath.TargetPath,
                flags = flags
            };
        }
    }
}
