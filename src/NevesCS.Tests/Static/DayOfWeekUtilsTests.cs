using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static
{
    public class DayOfWeekUtilsTests
    {
        [Theory]
        [InlineData(DayOfWeek.Monday, 1, DayOfWeek.Tuesday)]
        [InlineData(DayOfWeek.Saturday, 1, DayOfWeek.Sunday)]
        [InlineData(DayOfWeek.Sunday, 1, DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Friday, 3, DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Monday, 7, DayOfWeek.Monday)]
        public void AddDays_ResturnCorrect(DayOfWeek startDayOfWeek, int daysToAdd, DayOfWeek expectedDayOfWeek)
        {
            startDayOfWeek.AddDays(daysToAdd).Should().Be(expectedDayOfWeek);
            DayOfWeekUtils.AddDays(startDayOfWeek, daysToAdd).Should().Be(expectedDayOfWeek);
        }
    }
}
