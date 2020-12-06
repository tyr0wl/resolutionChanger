using ResolutionChanger.Win32.DisplayConfig.Data;
using ResolutionChanger.Win32.DisplayConfig.Modes;
using WrappedModes = ResolutionChanger.Data.Modes;

namespace ResolutionChanger.Win32.DisplayConfig.ModeInfo
{
    internal class ModeInfoFactory
    {
        public static ModeInfo Create(WrappedModes.ScreenMode screenMode)
        {
            return screenMode switch
            {
                WrappedModes.DesktopImageScreenMode desktopImageMode => CreateMode(desktopImageMode),
                WrappedModes.SourceScreenMode sourceMode => CreateMode(sourceMode),
                WrappedModes.TargetScreenMode targetMode => CreateMode(targetMode),
                _ => new ModeInfo(),
            };
        }

        private static ModeInfo CreateMode(WrappedModes.SourceScreenMode sourceScreenMode)
        {
            return new()
            {
                adapterId = (LuId) sourceScreenMode.DeviceId.AdapterId,
                id = sourceScreenMode.DeviceId.Id,
                infoType = ModeInfoType.Source,
                sourceMode = new SourceMode
                {
                    width = sourceScreenMode.Width,
                    height = sourceScreenMode.Height,
                    pixelFormat = sourceScreenMode.PixelFormat,
                    position = (PointL) sourceScreenMode.Position
                }
            };
        }

        private static ModeInfo CreateMode(WrappedModes.TargetScreenMode targetScreenMode)
        {
            return new()
            {
                adapterId = (LuId) targetScreenMode.DeviceId.AdapterId,
                id = targetScreenMode.DeviceId.Id,
                infoType = ModeInfoType.Target,
                targetMode = new TargetMode
                {
                    targetVideoSignalInfo = new VideoSignalInfo
                    {
                        pixelRate = targetScreenMode.PixelRate,
                        hSyncFreq = targetScreenMode.HorizontalSyncFrequency,
                        vSyncFreq = targetScreenMode.VerticalSyncFrequency,
                        vSyncFreqDivider = targetScreenMode.VerticalSyncFrequencyDivider,
                        activeSize = targetScreenMode.ActiveSize,
                        totalSize = targetScreenMode.TotalSize,
                        videoStandard = targetScreenMode.VideoStandard,
                        scanLineOrdering = targetScreenMode.ScanLineOrdering
                    }
                }
            };
        }

        private static ModeInfo CreateMode(WrappedModes.DesktopImageScreenMode desktopImageScreenMode)
        {
            return new()
            {
                adapterId = (LuId) desktopImageScreenMode.DeviceId.AdapterId,
                id = desktopImageScreenMode.DeviceId.Id,
                infoType = ModeInfoType.DesktopImage,
                desktopImageInfo = new DesktopImageInfo
                {
                    PathSourceSize = (PointL) desktopImageScreenMode.PathSourceSize,
                    DesktopImageRegion = desktopImageScreenMode.Region,
                    DesktopImageClip = desktopImageScreenMode.Clip
                }
            };
        }
    }
}