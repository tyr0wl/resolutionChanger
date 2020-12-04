using System;

namespace ResolutionChanger.Data
{
    public struct DeviceId : IEquatable<DeviceId>
    {
        public uint AdapterId { get; init; }
        public uint Id { get; set; }

        public bool Equals(DeviceId other)
        {
            return AdapterId == other.AdapterId && Id == other.Id;
        }

        public void Deconstruct(out uint adapterId, out uint id)
        {
            adapterId = AdapterId;
            id = Id;
        }

        public override bool Equals(object obj)
        {
            return obj is DeviceId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AdapterId, Id);
        }

        public static bool operator ==(DeviceId left, DeviceId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DeviceId left, DeviceId right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"{GetType().Name} {{{AdapterId},{Id}}}";
        }
    }
}