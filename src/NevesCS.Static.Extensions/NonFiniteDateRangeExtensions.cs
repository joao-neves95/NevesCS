using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class NonFiniteDateRangeExtensions
    {
        public static FiniteDateRangeValue ToFiniteDateRangeValue(this INonFiniteDateRange range)
        {
            return NonFiniteDateRangeUtils.ToFiniteDateRangeValue(range);
        }

        public static IEnumerable<FiniteDateRangeValue> SplitByDays(this INonFiniteDateRange range, int daysToSplitBy)
        {
            return NonFiniteDateRangeUtils.SplitByDays(range, daysToSplitBy);
        }
    }
}
