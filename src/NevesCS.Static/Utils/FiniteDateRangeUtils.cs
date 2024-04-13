using NevesCS.NonStatic.Models.ReferenceTypes;
using NevesCS.NonStatic.Models.ValueTypes;

namespace NevesCS.Static.Utils
{
    public static class FiniteDateRangeUtils
    {
        public static IEnumerable<FiniteDateRange> SplitDateRangeByDay(FiniteDateRange range, int daysToSplitBy)
        {
            return SplitDateRangeByDay(range.To<(DateTimeOffset, DateTimeOffset)>(), daysToSplitBy)
                .Select(rangeTuple => new FiniteDateRange(rangeTuple.Item1, rangeTuple.Item2));
        }

        public static IEnumerable<FiniteDateRangeValue> SplitDateRangeByDay(FiniteDateRangeValue range, int daysToSplitBy)
        {
            return SplitDateRangeByDay(range.To<(DateTimeOffset, DateTimeOffset)>(), daysToSplitBy)
                .Select(rangeTuple => new FiniteDateRangeValue(rangeTuple.Item1, rangeTuple.Item2));
        }

        public static IEnumerable<(DateTimeOffset, DateTimeOffset)> SplitDateRangeByDay(
            (DateTimeOffset start, DateTimeOffset end) range,
            int daysToSplitBy)
        {
            var days = (range.end - range.start).TotalDays;
            var count = days / daysToSplitBy;

            for (double index = 0; index < count; ++index)
            {
                var start = index == 0 ? range.start : range.start.AddDays(index * daysToSplitBy);
                var end = start.AddDays(daysToSplitBy);

                if (start < range.end)
                {
                    yield return (
                        start,
                        end > range.end
                            ? range.end
                            : end.AddSeconds(-1));
                }
            }
        }
    }
}
