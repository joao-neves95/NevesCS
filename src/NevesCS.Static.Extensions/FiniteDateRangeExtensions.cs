using NevesCS.NonStatic.Models.ReferenceTypes;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class FiniteDateRangeExtensions
    {
        public static IEnumerable<FiniteDateRange> SplitDateRangeByDay(this FiniteDateRange range, int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitDateRangeByDay(range, daysToSplitBy);
        }

        public static IEnumerable<FiniteDateRangeValue> SplitDateRangeByDay(this FiniteDateRangeValue range, int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitDateRangeByDay(range, daysToSplitBy);
        }

        public static IEnumerable<(DateTimeOffset, DateTimeOffset)> SplitDateRangeByDay(
            this (DateTimeOffset start, DateTimeOffset end) range,
            int daysToSplitBy)
        {
            return FiniteDateRangeUtils.SplitDateRangeByDay(range, daysToSplitBy);
        }
    }
}
