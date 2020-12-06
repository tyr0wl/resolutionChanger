using System;

namespace ResolutionChanger.Data.Paths
{
    public class SourcePath : PathData, IEquatable<SourcePath>
    {
        public string GdiDeviceName { get; init; }

        public bool Equals(SourcePath other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return DeviceId == other.DeviceId;
        }

        public SourcePath Copy
        (
            DeviceId? deviceId = null,
            bool? inUse = null,
            int? modeIndex = null,
            string gdiDeviceName = null
        )
        {
            return new()
            {
                DeviceId = deviceId ?? DeviceId,
                InUse = inUse ?? InUse,
                ModeIndex = modeIndex ?? ModeIndex,
                GdiDeviceName = gdiDeviceName ?? GdiDeviceName
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

            return obj.GetType() == GetType() && Equals((SourcePath) obj);
        }

        public override int GetHashCode()
        {
            return GdiDeviceName != null ? GdiDeviceName.GetHashCode() : 0;
        }

        public static bool operator ==(SourcePath left, SourcePath right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SourcePath left, SourcePath right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            var inUseString = InUse ? "Yes" : "No";
            return $@"{{ source {DeviceId}, {nameof(InUse)}: {inUseString}, [{ModeIndex}] }}";
        }
    }
}