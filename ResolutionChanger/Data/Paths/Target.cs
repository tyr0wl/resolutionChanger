using System;
using ResolutionChanger.Win32.DisplayConfig.Data;
using ResolutionChanger.Win32.DisplayConfig.Paths;

namespace ResolutionChanger.Data.Paths
{
    public class Target : PathData, IEquatable<Target>
    {
        public bool Available { get; init; }
        public Rational RefreshRate { get; init; }
        public Rotation Rotation { get; init; }
        public Scaling Scaling { get; init; }
        public ScanLineOrdering ScanLineOrdering { get; init; }
        public PathTargetInfoFlags Status { get; init; }
        public VideoOutputTechnology VideoOutput { get; init; }

        public bool Equals(Target other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return VideoOutput == other.VideoOutput && Rotation == other.Rotation && Scaling == other.Scaling && RefreshRate.Equals(other.RefreshRate) && ScanLineOrdering == other.ScanLineOrdering && Available == other.Available &&
                   Status == other.Status;
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

            return obj.GetType() == GetType() && Equals((Target) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) VideoOutput, (int) Rotation, (int) Scaling, RefreshRate, (int) ScanLineOrdering, Available, (int) Status);
        }

        public static bool operator ==(Target left, Target right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Target left, Target right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var modeIdxString = InvalidModeIndex ? "-" : ModeIndex.ToString();
            return $@"{{{GetType().Name} {DeviceId},{Status},[{modeIdxString}]->{VideoOutput}}}";
        }

        public Target Copy
        (
            DeviceId? deviceId = null,
            VideoOutputTechnology? videoOutput = null,
            Rotation? rotation = null,
            Scaling? scaling = null,
            Rational? refreshRate = null,
            ScanLineOrdering? scanLineOrdering = null,
            bool? available = null,
            bool? inUse = null,
            PathTargetInfoFlags? status = null,
            int? modeIndex = null
        )
        {
            return new()
            {
                DeviceId = deviceId ?? DeviceId,
                VideoOutput = videoOutput ?? VideoOutput,
                Rotation = rotation ?? Rotation,
                Scaling = scaling ?? Scaling,
                RefreshRate = refreshRate ?? RefreshRate,
                ScanLineOrdering = scanLineOrdering ?? ScanLineOrdering,
                Available = available ?? Available,
                InUse = inUse ?? InUse,
                Status = status ?? Status,
                ModeIndex = modeIndex ?? ModeIndex
            };
        }
    }
}