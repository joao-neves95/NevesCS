using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.NonStatic.Models.ValueTypes.Traits;
using NevesCS.Static.Constants;

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
            if (daysToSplitBy == Ints.One)
            {
                foreach (var dailyRange in SplitIntoDailyRanges(range))
                {
                    yield return dailyRange;
                }

                yield break;
            }

            var rangeEnd = range.End == DateTimeOffset.MaxValue ? range.End.AddDays(-daysToSplitBy) : range.End;

            var days = (rangeEnd - range.Start).TotalDays;
            var count = days / daysToSplitBy;

            for (double index = Ints.Zero; index < count; ++index)
            {
                var sliceStart = range.Start.AddDays(index * daysToSplitBy);

                if (sliceStart < rangeEnd)
                {
                    var sliceEnd = sliceStart.AddDays(daysToSplitBy);

                    yield return new FiniteDateRangeValue(
                        sliceStart,
                        sliceEnd > rangeEnd
                            ? rangeEnd
                            : sliceEnd.AddTicks(-Ints.One));
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<FiniteDateRangeValue> SplitIntoDailyRanges(FiniteDateRangeValue range)
        {
            var currentDuration = TimeSpan.Zero;
            var currentStart = range.Start;

            var finalDuration = (range.End == DateTimeOffset.MaxValue ? range.End.AddDays(-Ints.One) : range.End) - range.Start;

            while (currentDuration < finalDuration)
            {
                var timeLeftInTheDay = TimeSpan.FromDays(Ints.One) - currentStart.TimeOfDay;
                currentDuration = currentDuration.Add(timeLeftInTheDay);
                var todaysEnd = currentDuration <= finalDuration
                    ? currentStart.Add(timeLeftInTheDay).AddTicks(-Ints.One)
                    : range.End;

                yield return new FiniteDateRangeValue(currentStart, todaysEnd);
                currentStart = currentStart.Add(timeLeftInTheDay);
            }
        }
    }
}
