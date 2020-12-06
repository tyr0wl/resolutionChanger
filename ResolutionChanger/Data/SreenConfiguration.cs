using System.Collections.Generic;
using ResolutionChanger.Data.Modes;
using ResolutionChanger.Data.Paths;

namespace ResolutionChanger.Data
{
    public class ScreenConfiguration
    {
        public string Name { get; init; }
        public List<ScreenPath> Paths { get; init; } = new();
        public List<ScreenMode> Modes { get; init; } = new();

        public ScreenConfiguration Copy
        (
            string name = null,
            List<ScreenPath> paths = null,
            List<ScreenMode> modes = null
        )
        {
            return new()
            {
                Name = name ?? Name,
                Paths = paths ?? Paths,
                Modes = modes ?? Modes,
            };
        }
    }
}
