using System;
using ResolutionChanger.Win32;

namespace ResolutionChanger.Data.Modes
{
    internal class DesktopImageScreenMode : ScreenMode, IEquatable<DesktopImageScreenMode>
    {
        public RectangleL Clip { get; init; }
        public Point PathSourceSize { get; init; }
        public RectangleL Region { get; init; }

        public void Deconstruct(out Point pathSourceSize, out RectangleL region, out RectangleL clip)
        {
            pathSourceSize = PathSourceSize;
            region = Region;
            clip = Clip;
        }

        public bool Equals(DesktopImageScreenMode other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return PathSourceSize.Equals(other.PathSourceSize) && Region.Equals(other.Region) && Clip.Equals(other.Clip);
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

            return obj.GetType() == GetType() && Equals((DesktopImageScreenMode) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PathSourceSize, Region, Clip);
        }

        public static bool operator ==(DesktopImageScreenMode left, DesktopImageScreenMode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DesktopImageScreenMode left, DesktopImageScreenMode right)
        {
            return !Equals(left, right);
        }
    }
}