using NevesCS.Abstractions.Traits;
using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class InfiniteDateRange
        : INonFiniteDateRange,
          IToFiniteDateRangeValueConvertible,
          IConvertibleToValue<InfiniteDateRangeValue>
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override bool Equals(object obj)
        {
            return obj is InfiniteDateRange dr && dr.Start == Start;
        }

        public InfiniteDateRangeValue ToValue()
        {
            return new InfiniteDateRangeValue(Start);
        }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            return FiniteDateRangeValue.From(this);
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

        public static bool operator ==(InfiniteDateRange left, InfiniteDateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InfiniteDateRange left, InfiniteDateRange right)
        {
            return !left.Equals(right);
        }
    }
}
