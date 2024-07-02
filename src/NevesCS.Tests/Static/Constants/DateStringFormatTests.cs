using FluentAssertions;

using NevesCS.Static.Extensions;

namespace NevesCS.Tests.Static.Constants
{
    public class DateStringFormatTests
    {

        [Fact]
        public void ToIso8601FormatString_Passes()
        {
            new DateTimeOffset(2024, 06, 01, 12, 01, 02, 100, TimeSpan.Zero)
                .ToIso8601FormatString()
                .Should()
                .Be("2024-06-01T12:01:02+00:00");

            new DateTimeOffset(2024, 06, 01, 12, 01, 02, 100, TimeSpan.FromHours(1))
                .ToIso8601FormatString()
                .Should()
                .Be("2024-06-01T12:01:02+01:00");
        }

        [Fact]
        public void ToDetailedFormatString_Passes()
        {
            new DateTimeOffset(2024, 06, 01, 12, 01, 02, 100, TimeSpan.Zero)
                .ToDetailedFormatString()
                .Should()
                .Be("2024-06-01T12:01:02.1000000+00:00");

            new DateTimeOffset(2024, 06, 01, 12, 01, 02, 100, TimeSpan.FromHours(1))
                .ToDetailedFormatString()
                .Should()
                .Be("2024-06-01T12:01:02.1000000+01:00");
        }
    }
}
