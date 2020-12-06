using System;
using ResolutionChanger.Win32.DisplayConfig.Data;
using ResolutionChanger.Win32.DisplayConfig.Modes;

namespace ResolutionChanger.Data.Modes
{
    public class TargetScreenMode : ScreenMode, IEquatable<TargetScreenMode>
    {
        public DisplayConfig2dRegion ActiveSize { get; init; }
        public Rational HorizontalSyncFrequency { get; init; }
        public ulong PixelRate { get; init; }
        public ScanLineOrdering ScanLineOrdering { get; init; }
        public DisplayConfig2dRegion TotalSize { get; init; }
        public Rational VerticalSyncFrequency { get; init; }
        public ushort VerticalSyncFrequencyDivider { get; init; }
        public VideoSignalStandard VideoStandard { get; init; }

        public bool Equals(TargetScreenMode other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return ActiveSize.Equals(other.ActiveSize) && HorizontalSyncFrequency.Equals(other.HorizontalSyncFrequency) && PixelRate == other.PixelRate && ScanLineOrdering == other.ScanLineOrdering && TotalSize.Equals(other.TotalSize) &&
                   VerticalSyncFrequency.Equals(other.VerticalSyncFrequency) && VerticalSyncFrequencyDivider == other.VerticalSyncFrequencyDivider && VideoStandard == other.VideoStandard;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((TargetScreenMode) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ActiveSize, HorizontalSyncFrequency, PixelRate, (int) ScanLineOrdering, TotalSize, VerticalSyncFrequency, VerticalSyncFrequencyDivider, (int) VideoStandard);
        }

        public static bool operator ==(TargetScreenMode left, TargetScreenMode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TargetScreenMode left, TargetScreenMode right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return
                $"{{ {GetType().Name} {VideoStandard}, hSync:{HorizontalSyncFrequency}, vSync:{VerticalSyncFrequency}({VerticalSyncFrequencyDivider}), {nameof(ActiveSize)}: {ActiveSize}, {nameof(TotalSize)}: {TotalSize}, {ScanLineOrdering} }}";
        }
    }
}