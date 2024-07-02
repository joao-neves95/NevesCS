using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;

namespace NevesCS.Static.Utils
{
    public static class NonFiniteDateRangeUtils
    {
        public static FiniteDateRangeValue ToFiniteDateRangeValue(INonFiniteDateRange range)
        {
            return new FiniteDateRangeValue(range.Start, range.End ?? DateTimeOffset.MaxValue);
        }

        public static IEnumerable<FiniteDateRangeValue> SplitByDays(INonFiniteDateRange range, int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitByDays(range, daysToSplitBy);
        }
    }
}
