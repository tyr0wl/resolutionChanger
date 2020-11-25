using System.Collections.Generic;

namespace ResolutionChanger
{
    public class Monitor
    {
        public uint AdapterId { get; set; }

        public uint SourceId { get; set; }
        public uint TargetId { get; set; }
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
            return $"{DisplayName}({AdapterId},{SourceId},{TargetId},{primaryString}{activeString}){currentResolution} ({Position})";
        }
    }
}