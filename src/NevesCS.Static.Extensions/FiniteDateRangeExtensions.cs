using NevesCS.Abstractions.Types;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class FiniteDateRangeExtensions
    {
        public static FiniteDateRangeValue ToFiniteDateRangeValue(IFiniteDateRange range)
        {
            return FiniteDateRangeUtils.ToFiniteDateRangeValue(range);
        }

        public static IEnumerable<FiniteDateRangeValue> SplitByDays(this IFiniteDateRange range, int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitByDays(range, daysToSplitBy);
        }
    }
}
