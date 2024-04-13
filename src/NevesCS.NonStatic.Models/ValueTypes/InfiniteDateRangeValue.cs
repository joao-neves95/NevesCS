using NevesCS.Abstractions.Traits;

namespace NevesCS.NonStatic.Models.ValueTypes
{
    public readonly struct InfiniteDateRangeValue
    {
        public InfiniteDateRangeValue(DateTimeOffset start)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            Start = start;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset? End { get; }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override readonly bool Equals(object obj)
        {
            return obj is FiniteDateRangeValue dr
                && dr.Start == Start;
        }


        public static bool operator !=(InfiniteDateRangeValue left, InfiniteDateRangeValue right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(InfiniteDateRangeValue left, InfiniteDateRangeValue right)
        {
            return left.Equals(right);
        }
    }
}
