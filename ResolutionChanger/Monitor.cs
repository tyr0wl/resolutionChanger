using System.Collections.Generic;

namespace ResolutionChanger
{
    public class Monitor
    {
        public string DeviceName { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            var primaryString = IsPrimary ? "P" : null;
            var activeString = IsActive ? "A" : "D";
            return $"{DeviceName}({primaryString}{activeString})";
        }
    }
}