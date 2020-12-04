namespace ResolutionChanger.Data.Paths
{
    public abstract class PathData
    {
        public DeviceId DeviceId { get; init; }
        public bool InUse { get; init; }
        public int ModeIndex { get; init; }
        public bool InvalidModeIndex => ModeIndex == -1;
    }
}