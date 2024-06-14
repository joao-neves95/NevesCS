using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ValueTypes
{
    public readonly struct InfiniteDateRangeValue
        : INonFiniteDateRange,
          IToFiniteDateRangeValueConvertible
    {
        public InfiniteDateRangeValue([NotNull, DisallowNull] DateTimeOffset start)
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

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            return new FiniteDateRangeValue(
                Start,
                End ?? DateTimeOffset.MaxValue.Add(-TimeSpan.FromDays(1)));
        }

        public new bool Equals(object? x, object? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDateRange? x, IDateRange? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] IDateRange obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IDateRange? other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(INonFiniteDateRange? x, INonFiniteDateRange? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] INonFiniteDateRange obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(INonFiniteDateRange? other)
        {
            throw new NotImplementedException();
        }
    }
}
