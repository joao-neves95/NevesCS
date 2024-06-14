using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

using System.Diagnostics.CodeAnalysis;

namespace NevesCS.NonStatic.Models.ReferenceTypes
{
    public readonly record struct InfiniteDateRangeRecord([NotNull, DisallowNull] DateTimeOffset Start, DateTimeOffset? End)
        : INonFiniteDateRange,
          IToFiniteDateRangeValueConvertible
    {
        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }

        public int GetHashCode([DisallowNull] INonFiniteDateRange obj)
        {
            return HashCode.Combine(obj.Start, obj.End);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }

        public new bool Equals(object? x, object? y)
        {
            return x is InfiniteDateRangeRecord drX && y is InfiniteDateRangeRecord drY
                   && drX.Start == drY.Start;
        }

        public bool Equals(INonFiniteDateRange? x, INonFiniteDateRange? y)
        {
            return x?.Start == y?.Start;
        }

        public bool Equals(INonFiniteDateRange? other)
        {
            throw new NotImplementedException();
        }

        public FiniteDateRangeValue ToFiniteDateRangeValue()
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
    }
}
