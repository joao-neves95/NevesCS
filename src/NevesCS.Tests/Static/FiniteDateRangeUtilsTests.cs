using FluentAssertions;

using NevesCS.NonStatic.Models.ReferenceTypes;
using NevesCS.NonStatic.Models.ValueTypes;
using NevesCS.Static.Extensions;

namespace NevesCS.Tests.Static
{
    // TODO: Add test to check if the end of the last date range is the same as the original end.
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
            dateRanges[0].End.Should().Be(start.AddDays(30).AddTicks(-1));
            dateRanges[1].Start.Should().Be(start.AddDays(30));
            dateRanges[1].End.Should().Be(start.AddDays(30).AddDays(30).AddTicks(-1));
            dateRanges[^2].Start.Should().Be(start.AddDays(300));
            dateRanges[^2].End.Should().Be(start.AddDays(330).AddTicks(-1));
            dateRanges[^1].Start.Should().Be(start.AddDays(330));
            dateRanges[^1].End.Should().Be(start.AddDays(360).AddTicks(-1));
            dateRanges[^1].Start.Should().BeBefore(dateRanges[^1].End);
        }

        [Theory]
        [InlineData(60, 360)]
        [InlineData(123, 546)]
        [InlineData(35, 234)]
        [InlineData(645, 2134)]
        [InlineData(12, 242)]
        [InlineData(203, 1231)]
        [InlineData(1, 56)]
        public void SplitDateRangeByDay_WhenSplitBy_SplitsCorrectly(int splitBy, int daysToAdd)
        {
            var start = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var dateRange = new FiniteDateRangeValue(start, start.AddDays(daysToAdd));

            var dateRanges = dateRange.SplitByDays(splitBy).ToArray();

            var count = (int)Math.Ceiling((double)daysToAdd / splitBy);
            Assert(dateRanges, dateRange, count, splitBy == 1);

            var infiniteDateRange = new InfiniteDateRange(start);
            dateRanges = infiniteDateRange.SplitByDays(splitBy).ToArray();
            count = (int)Math.Ceiling((DateTimeOffset.MaxValue.AddDays(-splitBy) - infiniteDateRange.Start).TotalDays / splitBy);
            Assert(dateRanges, dateRange, count, splitBy == 1);
        }

        private static void Assert(FiniteDateRangeValue[] dateRanges, FiniteDateRangeValue originalDateRange, int count, bool splitBy1Day)
        {
            dateRanges.Length.Should().Be(count);
            var index = 0;
            foreach (var dateRange in dateRanges)
            {
                var expectedStart = index == 0 ? originalDateRange.Start : dateRanges[index - 1].End.AddTicks(1);
                dateRange.Start.Should().Be(expectedStart);

                var expectedEnd = index == count ? originalDateRange.End : dateRanges[index].End;
                dateRange.End.Should().Be(expectedEnd);

                if (index > 0 && splitBy1Day)
                {
                    dateRange.Start.Day.Should().NotBe(dateRanges[index - 1].Start.Day);
                }

                ++index;
            }

            dateRanges[^1].Start.Should().BeBefore(dateRanges[^1].End);
        }
    }
}
