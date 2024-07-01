using NevesCS.Abstractions.Types;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class InfiniteDateRange : INonFiniteDateRange
    {
        public InfiniteDateRange([NotNull, DisallowNull] DateTimeOffset start)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            Start = start;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset? End { get; }

        public static bool operator !=(InfiniteDateRange left, InfiniteDateRange right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(InfiniteDateRange left, InfiniteDateRange right)
        {
            return left.Equals(right);
        }

        public bool Equals(INonFiniteDateRange? x, INonFiniteDateRange? y)
        {
            return x?.Equals(y) ?? false;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is INonFiniteDateRange dr && this.Equals(dr);
        }

        public bool Equals(INonFiniteDateRange? other)
        {
            return Start == other?.Start && End == other.End;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public int GetHashCode([DisallowNull] INonFiniteDateRange obj)
        {
            return HashCode.Combine(Start, End, obj.Start, obj.End);
        }
    }
}
