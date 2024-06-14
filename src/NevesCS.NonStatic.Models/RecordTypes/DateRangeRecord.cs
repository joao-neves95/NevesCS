using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public readonly record struct DateRangeRecord : INonFiniteDateRange, IToFiniteDateRangeValueConvertible
    {
        public DateRangeRecord([NotNull, DisallowNull] DateTimeOffset start, DateTimeOffset? end)
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

        public new bool Equals(object? x, object? y)
        {
            throw new NotImplementedException();
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] IDateRange obj)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] INonFiniteDateRange obj)
        {
            throw new NotImplementedException();
        }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            throw new NotImplementedException();
        }

        //public override bool Equals(object obj)
        //{
        //    return obj is DateRangeRecord dr && dr.Start == Start;
        //}

        //public static bool operator ==(DateRangeRecord left, DateRangeRecord right)
        //{
        //    return left.Equals(right);
        //}

        //public static bool operator !=(DateRangeRecord left, DateRangeRecord right)
        //{
        //    return !left.Equals(right);
        //}
    }
}
