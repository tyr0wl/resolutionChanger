using ResolutionChanger.Win32.DisplayConfig.Paths;

namespace ResolutionChanger.Data.Paths
{
    internal class ScreenPathFactory
    {
        public static ScreenPath Create(PathInfo pathInfo)
        {
            return new()
            {
                SourcePath = SourcePathFactory.Create(pathInfo.sourceInfo),
                TargetPath = TargetPathFactory.Create(pathInfo.targetInfo),
                Active = pathInfo.flags.HasFlag(PathInfoFlags.Active),
                SupportsVirtualMode = pathInfo.flags.HasFlag(PathInfoFlags.SupportVirtualMode)
            };
        }
    }
}