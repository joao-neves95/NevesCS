using FluentAssertions;

using NevesCS.NonStatic.Models;
using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static
{
    public class EnumUtilsTests
    {
        [Theory]
        [InlineData(ResultType.Failure, "Failure")]
        [InlineData(ResultType.Warning, "Warning")]
        [InlineData(ResultType.Success, "Success")]
        public void Should_GetTheDescriptionAttributeAsString(ResultType enumValue, string expected)
        {
            enumValue.GetDescription().Should().Be(expected);
            EnumUtils.GetDescription(enumValue).Should().Be(expected);
        }
    }
}
