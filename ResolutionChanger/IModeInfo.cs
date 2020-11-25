using ResolutionChanger.Win32.DisplayConfig;
using ResolutionChanger.Win32.DisplayConfig.Data;

namespace ResolutionChanger
{
    public interface IModeInfo
    {
        public LuId AdapterId { get; init; }
        public LuId Id { get; init; }
    }

    public class SourceModeInfo : IModeInfo
    {
        public LuId AdapterId { get; init; }
        public LuId Id { get; init; }
        

    }
}
