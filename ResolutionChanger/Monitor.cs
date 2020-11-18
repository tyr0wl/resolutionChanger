using System.Collections.Generic;

namespace ResolutionChanger
{
    public class Monitor
    {
        public uint Id { get; set; }
        public string DeviceName { get; set; }
        public List<Resolution> SupportedResolutions { get; } = new List<Resolution>();
        public Resolution CurrentResolution { get; set; }
        public Point Position { get; set; }

        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            var primaryString = IsPrimary ? "P" : null;
            var activeString = IsActive ? "A" : "D";
            var currentResolution = !Equals(CurrentResolution, Resolution.Empty) ? $" {CurrentResolution}" : null;
            return $"{DeviceName}({primaryString}{activeString}){currentResolution} ({Position})";
        }
    }
}