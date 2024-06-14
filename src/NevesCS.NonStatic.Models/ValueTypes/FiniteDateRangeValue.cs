using NevesCS.Abstractions.Traits;
using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ReferenceTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ValueTypes
{
    public readonly struct FiniteDateRangeValue
        : IFiniteDateRange,
          IConvertible<(DateTimeOffset start, DateTimeOffset end)>,
          IToFiniteDateRangeValueConvertible
    {
        public FiniteDateRangeValue([NotNull, DisallowNull] DateTimeOffset start, DateTimeOffset end)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            if (end == default)
            {
                throw new ArgumentNullException(nameof(end));
            }

            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset End { get; }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override readonly bool Equals(object obj)
        {
            return obj is FiniteDateRangeValue dr
                && dr.Start == Start
                && dr.End == End;
        }

        public static bool operator ==(FiniteDateRangeValue left, FiniteDateRangeValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FiniteDateRangeValue left, FiniteDateRangeValue right)
        {
            return !left.Equals(right);
        }

        public (DateTimeOffset start, DateTimeOffset end) To<Out>()
        {
            return (Start, End);
        }

        public static FiniteDateRangeValue From(INonFiniteDateRange dateRange)
        {
            return new FiniteDateRangeValue(
                dateRange.Start,
                dateRange.End ?? DateTimeOffset.MaxValue);
        }

        public static FiniteDateRangeValue From(IFiniteDateRange dateRange, TimeSpan offsetFromMaxDateTime)
        {
            return new FiniteDateRangeValue(dateRange.Start, dateRange.End);
        }

        public static FiniteDateRangeValue FromNonFiniteDateRangeToNow(INonFiniteDateRange infiniteDateRange)
        {
            return new FiniteDateRangeValue(
                infiniteDateRange.Start,
                infiniteDateRange.End ?? (
                    infiniteDateRange.Start.Offset == TimeSpan.Zero
                        ? DateTimeOffset.UtcNow
                        : DateTimeOffset.Now));
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

        public bool Equals(IFiniteDateRange? x, IFiniteDateRange? y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] IFiniteDateRange obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IFiniteDateRange? other)
        {
            throw new NotImplementedException();
        }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            throw new NotImplementedException();
        }
    }
}
