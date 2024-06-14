using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class DateRange : INonFiniteDateRange, IToFiniteDateRangeValueConvertible
    {
        public DateRange([NotNull, DisallowNull] DateTimeOffset start, DateTimeOffset? end)
        {
            if (start == default)
            {
                throw new ArgumentNullException(nameof(start));
            }

            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; }

        public DateTimeOffset? End { get; }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            return FiniteDateRangeValue.From(this);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public int GetHashCode(object obj)
        {
            var dr = (DateRange)obj;
            return HashCode.Combine(dr.Start, dr.End);
        }

        public int GetHashCode([DisallowNull] IDateRange obj)
        {
            return HashCode.Combine(obj.Start);
        }

        public int GetHashCode([DisallowNull] INonFiniteDateRange obj)
        {
            return HashCode.Combine(obj.Start, obj.End);
        }

        public override bool Equals(object obj)
        {
            return obj is DateRange dr && dr.Start == Start && dr.End == End;
        }

        public new bool Equals(object? x, object? y)
        {
            return x is DateRange drX && y is DateRange drY
                && drX.Start == drY.Start && drX.End == drY.End;
        }


        public bool Equals(IDateRange? x, IDateRange? y)
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

        public bool Equals(INonFiniteDateRange? other)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(DateRange left, DateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DateRange left, DateRange right)
        {
            return !left.Equals(right);
        }
    }
}
