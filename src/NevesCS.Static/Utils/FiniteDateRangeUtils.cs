using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;

namespace NevesCS.Static.Utils
{
    public static class FiniteDateRangeUtils
    {
        public static IEnumerable<FiniteDateRangeValue> SplitByDays(IToFiniteDateRangeValueConvertible range, int daysToSplitBy)
        {
            return SplitByDays(range.ToFiniteDateRangeValue(), daysToSplitBy);
        }

        public static IEnumerable<FiniteDateRangeValue> SplitByDays(FiniteDateRangeValue range, int daysToSplitBy)
        {
            var days = (range.End - range.Start).TotalDays;
            var count = days / daysToSplitBy;

            for (double index = 0; index < count; ++index)
            {
                var start = index == 0 ? range.Start : range.Start.AddDays(index * daysToSplitBy);
                var end = start.AddDays(daysToSplitBy);

                if (start < range.End)
                {
                    yield return new FiniteDateRangeValue(
                        start,
                        end > range.End
                            ? range.End
                            : end.AddTicks(-1));
                }
            }
        }
    }
}
