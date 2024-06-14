using FluentAssertions;

using NevesCS.NonStatic.Models.ReferenceTypes;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.Static.Extensions;

namespace NevesCS.Tests.Static
{
    public class FiniteDateRangeUtilsTests
    {
        [Fact]
        public void SplitDateRangeByDay_WhenDefault_SplitsCorrectly()
        {
            // Arrange
            var start = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var dateRange = new FiniteDateRangeValue(start, start.AddDays(360));

            // Act
            var dateRanges = dateRange.SplitByDays(30).ToList();

            // Assert
            dateRanges.Count.Should().Be(360 / 30);
            dateRanges[0].Start.Should().Be(start);
            dateRanges[0].End.Should().Be(start.AddDays(30).AddSeconds(-1));
            dateRanges[1].Start.Should().Be(start.AddDays(30));
            dateRanges[1].End.Should().Be(start.AddDays(30).AddDays(30).AddSeconds(-1));
            dateRanges[^2].Start.Should().Be(start.AddDays(300));
            dateRanges[^2].End.Should().Be(start.AddDays(330).AddSeconds(-1));
            dateRanges[^1].Start.Should().Be(start.AddDays(330));
            dateRanges[^1].End.Should().Be(start.AddDays(360).AddSeconds(-1));
            dateRanges[^1].Start.Should().BeBefore(dateRanges[^1].End);
        }

        [Theory]
        [InlineData(60, 360)]
        [InlineData(123, 546)]
        [InlineData(35, 234)]
        [InlineData(645, 2134)]
        [InlineData(12, 242)]
        [InlineData(203, 1231)]
        public void SplitDateRangeByDay_WhenSplitBy_SplitsCorrectly(int splitBy, int daysToAdd)
        {
            // Arrange
            var start = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var dateRange = new FiniteDateRangeValue(start, start.AddDays(daysToAdd));

            // Act
            var dateRanges = dateRange.SplitByDays(splitBy).ToList();

            // Assert
            var count = (int)Math.Ceiling((double)daysToAdd / splitBy);
            Assert(dateRanges, dateRange, count);
        }

        private static void Assert(List<FiniteDateRangeValue> dateRanges, FiniteDateRangeValue originalDateRange, int count)
        {
            dateRanges.Count.Should().Be(count);
            var index = 0;
            foreach (var dateRange in dateRanges)
            {
                var previousStart = index == 0 ? originalDateRange.Start : dateRanges[index - 1].End.AddSeconds(1);
                dateRange.Start.Should().Be(previousStart);

                var endDate = index == count ? originalDateRange.End : dateRanges[index].End;
                dateRange.End.Should().Be(endDate);

                index++;
            }

            dateRanges[^1].Start.Should().BeBefore(dateRanges[^1].End);
        }
    }
}
