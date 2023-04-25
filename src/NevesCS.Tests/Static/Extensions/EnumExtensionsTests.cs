
using FluentAssertions;

using NevesCS.Static.Enums;
using NevesCS.Static.Extensions;

namespace NevesCS.Tests.Static.Extensions
{
    public class EnumExtensionsTests
    {
        [Theory]
        [InlineData(ResultType.Failure, "Failure")]
        [InlineData(ResultType.Warning, "Warning")]
        [InlineData(ResultType.Success, "Success")]
        public void ShouldConvertEnumToString(ResultType enumValue, string expected)
        {
            var obtained = enumValue.GetDescription();

            expected.Should().Be(obtained);
        }
    }
}
