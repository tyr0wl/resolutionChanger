using ResolutionChanger.Win32.DisplayConfig.Paths;

namespace ResolutionChanger.Data.Paths
{
    internal class SourcePathFactory
    {
        public static SourcePath Create(PathSourceInfo sourceInfo)
        {
            var sourceDeviceName = Win32ApiWrapper.GetGdiDeviceNameFromSource(sourceInfo.adapterId, sourceInfo.id);
            return new()
            {
                DeviceId = new DeviceId
                {
                    AdapterId = sourceInfo.adapterId.LowPart,
                    Id = sourceInfo.id
                },
                InUse = sourceInfo.statusFlags.HasFlag(SourceInfoFlags.InUse),
                ModeIndex = sourceInfo.InvalidModeIdx ? -1 : (int)sourceInfo.modeInfoIdx,
                GdiDeviceName = sourceDeviceName.viewGdiDeviceName,
            };
        }
    }
}
