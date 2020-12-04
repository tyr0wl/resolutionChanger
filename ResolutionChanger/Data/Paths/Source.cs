using System;

namespace ResolutionChanger.Data.Paths
{
    public class Source : PathData, IEquatable<PathData>
    {
        public bool Equals(PathData other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return DeviceId.Equals(other.DeviceId) && InUse == other.InUse && ModeIndex == other.ModeIndex;
        }

        public Source Copy
        (
            DeviceId? deviceId = null,
            bool? inUse = null,
            int? modeIndex = null
        )
        {
            return new()
            {
                DeviceId = deviceId ?? DeviceId,
                InUse = inUse ?? InUse,
                ModeIndex = modeIndex ?? ModeIndex
            };
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

            return obj.GetType() == GetType() && Equals((PathData) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DeviceId, InUse, ModeIndex);
        }

        public static bool operator ==(Source left, Source right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Source left, Source right)
        {
            return !Equals(left, right);
        }
    }
}