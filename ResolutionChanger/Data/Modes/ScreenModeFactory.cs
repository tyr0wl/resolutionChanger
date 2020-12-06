using System;
using ResolutionChanger.Win32.DisplayConfig.ModeInfo;

namespace ResolutionChanger.Data.Modes
{
    internal class ScreenModeFactory
    {
        public static ScreenMode Create(ModeInfo modeInfo)
        {
            return modeInfo.infoType switch
            {
                ModeInfoType.None => new EmptyScreenMode { DeviceId = new DeviceId { AdapterId = modeInfo.adapterId.LowPart, Id = modeInfo.id, } },
                ModeInfoType.Source => CreateSourceMode(modeInfo),
                ModeInfoType.Target => CreateTargetMode(modeInfo),
                ModeInfoType.DesktopImage => CreateDesktopImageMode(modeInfo),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static SourceScreenMode CreateSourceMode(ModeInfo modeInfo)
        {
            var sourceMode = modeInfo.sourceMode;
            return new SourceScreenMode
            {
                DeviceId = new DeviceId
                {
                    AdapterId = modeInfo.adapterId.LowPart,
                    Id = modeInfo.id
                },
                Width = sourceMode.width,
                Height = sourceMode.height,
                PixelFormat = sourceMode.pixelFormat,
                Position = (Point) sourceMode.position
            };
        }

        private static TargetScreenMode CreateTargetMode(ModeInfo modeInfo)
        {
            var videoSignalInfo = modeInfo.targetMode.targetVideoSignalInfo;
            return new TargetScreenMode
            {
                DeviceId = new DeviceId
                {
                    AdapterId = modeInfo.adapterId.LowPart,
                    Id = modeInfo.id
                },
                PixelRate = videoSignalInfo.pixelRate,
                HorizontalSyncFrequency = videoSignalInfo.hSyncFreq,
                VerticalSyncFrequency = videoSignalInfo.vSyncFreq,
                VerticalSyncFrequencyDivider = videoSignalInfo.vSyncFreqDivider,
                ActiveSize = videoSignalInfo.activeSize,
                TotalSize = videoSignalInfo.totalSize,
                VideoStandard = videoSignalInfo.videoStandard,
                ScanLineOrdering = videoSignalInfo.scanLineOrdering,
            };
        }

        private static DesktopImageScreenMode CreateDesktopImageMode(ModeInfo modeInfo)
        {
            var desktopImageInfo = modeInfo.desktopImageInfo;
            return new DesktopImageScreenMode
            {
                DeviceId = new DeviceId
                {
                    AdapterId = modeInfo.adapterId.LowPart,
                    Id = modeInfo.id
                },
                PathSourceSize = (Point) desktopImageInfo.PathSourceSize,
                Region = desktopImageInfo.DesktopImageRegion,
                Clip = desktopImageInfo.DesktopImageClip,
            };
        }
    }
}