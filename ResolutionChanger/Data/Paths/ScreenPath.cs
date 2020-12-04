using System;

namespace ResolutionChanger.Data.Paths
{
    public class ScreenPath : IEquatable<ScreenPath>
    {
        public bool Active { get; init; }
        public Source Source { get; init; }
        public bool SupportsVirtualMode { get; init; }
        public Target Target { get; init; }

        public bool Equals(ScreenPath other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Source, other.Source) && Equals(Target, other.Target) && Active == other.Active && SupportsVirtualMode == other.SupportsVirtualMode;
        }

        public ScreenPath Copy
        (
            Source source = null,
            Target target = null,
            bool? active = null,
            bool? supportsVirtualMode = null
        )
        {
            return new()
            {
                Source = source ?? Source,
                Target = target ?? Target,
                Active = active ?? Active,
                SupportsVirtualMode = supportsVirtualMode ?? SupportsVirtualMode
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

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((ScreenPath) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Source, Target, Active, SupportsVirtualMode);
        }

        public static bool operator ==(ScreenPath left, ScreenPath right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ScreenPath left, ScreenPath right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{{path {Source},{Target},{(Active ? "active" : "")}}}";
        }
    }
}