using System.Collections.Generic;
using ResolutionChanger.Data;

namespace ResolutionChanger
{
    public class Monitor
    {
        public DeviceId SourceId { get; set; }
        public DeviceId TargetId { get; set; }
        public string DisplayName { get; set; }
        public string DevicePath { get; set; }
        public List<Resolution> SupportedResolutions { get; } = new();
        public Resolution CurrentResolution { get; set; }
        public Point Position { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            var primaryString = IsPrimary ? "P" : null;
            var activeString = IsActive ? "A" : "D";
            var currentResolution = !Equals(CurrentResolution, Resolution.Empty) ? $" {CurrentResolution}" : null;
            return $"{DisplayName}({SourceId},{TargetId},{primaryString}{activeString}){currentResolution} ({Position})";
        }
    }
}