using ResolutionChanger.Win32.DisplayConfig.Paths;

namespace ResolutionChanger.Data.Paths
{
    internal class TargetPathFactory
    {
        public static TargetPath Create(PathTargetInfo targetInfo)
        {
            var targetDeviceName = Win32ApiWrapper.GetTargetDeviceName(targetInfo.adapterId, targetInfo.id);
            
            return new TargetPath
            {
                DeviceId = new DeviceId
                {
                    AdapterId = targetInfo.adapterId.LowPart,
                    Id = targetInfo.id
                },
                InUse = targetInfo.statusFlags.HasFlag(PathTargetInfoFlags.InUse),
                ModeIndex = targetInfo.InvalidModeIdx ? -1 : (int)targetInfo.modeInfoIdx,
                VideoOutput = targetInfo.outputTechnology,
                Available = targetInfo.targetAvailable,
                RefreshRate = targetInfo.refreshRate,
                Rotation = targetInfo.rotation,
                Scaling = targetInfo.scaling,
                ScanLineOrdering = targetInfo.scanLineOrdering,
                Status = targetInfo.statusFlags,
                MonitorDeviceName = targetDeviceName.monitorFriendlyDeviceName,
                MonitorDevicePath = targetDeviceName.monitorDevicePath,
                ConnectorInstance = targetDeviceName.connectorInstance,
                EdidManufactureId = targetDeviceName.edidManufactureId,
                EdidProductCodeId = targetDeviceName.edidProductCodeId,
            };
        }
    }
}
