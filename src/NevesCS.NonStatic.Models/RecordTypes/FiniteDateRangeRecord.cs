using NevesCS.Abstractions.Traits;
using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public readonly record struct FiniteDateRangeRecord
        : IFiniteDateRange,
          IToFiniteDateRangeValueConvertible,
          IConvertible<(DateTimeOffset start, DateTimeOffset end)>
    {
        public FiniteDateRangeRecord([NotNull, DisallowNull] DateTimeOffset start, DateTimeOffset end)
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

        public bool Equals(IFiniteDateRange? x, IFiniteDateRange? y)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IFiniteDateRange? other)
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

        public int GetHashCode([DisallowNull] IFiniteDateRange obj)
        {
            throw new NotImplementedException();
        }

        //public override bool Equals(object obj)
        //{
        //    return obj is FiniteDateRangeRecord dr
        //        && dr.Start == Start
        //        && dr.End == End;
        //}

        //public static bool operator ==(FiniteDateRangeRecord left, FiniteDateRangeRecord right)
        //{
        //    return left.Equals(right);
        //}

        //public static bool operator !=(FiniteDateRangeRecord left, FiniteDateRangeRecord right)
        //{
        //    return !left.Equals(right);
        //}

        public (DateTimeOffset start, DateTimeOffset end) To<Out>()
        {
            return (Start, End);
        }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
        {
            throw new NotImplementedException();
        }
    }
}
