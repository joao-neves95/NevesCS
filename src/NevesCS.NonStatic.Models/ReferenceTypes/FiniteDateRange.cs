using NevesCS.Abstractions.Traits;
using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public class FiniteDateRange
        : IFiniteDateRange,
          IToFiniteDateRangeValueConvertible,
          IConvertible<(DateTimeOffset start, DateTimeOffset end)>
    {
        public FiniteDateRange([NotNull, DisallowNull] DateTimeOffset start, DateTimeOffset end)
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public override bool Equals(object obj)
        {
            return obj is FiniteDateRange dr
                && dr.Start == Start
                && dr.End == End;
        }

        public static bool operator ==(FiniteDateRange left, FiniteDateRange right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FiniteDateRange left, FiniteDateRange right)
        {
            return !left.Equals(right);
        }

        public (DateTimeOffset start, DateTimeOffset end) To<Out>()
        {
            return (Start, End);
        }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            return new FiniteDateRangeValue(Start, End);
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
    }
}
