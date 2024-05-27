using NevesCS.NonStatic.Models.ReferenceTypes;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class FiniteDateRangeExtensions
    {
        public static IEnumerable<FiniteDateRangeValue> SplitByDays(this FiniteDateRange range, int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitByDays(range, daysToSplitBy);
        }

        public static IEnumerable<FiniteDateRangeValue> SplitByDays(this FiniteDateRangeValue range, int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitByDays(range, daysToSplitBy);
        }
    }
}
