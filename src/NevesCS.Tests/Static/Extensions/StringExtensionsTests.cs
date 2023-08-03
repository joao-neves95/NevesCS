using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null, "ABC", false)]
        [InlineData(null, null, false)]
        [InlineData("", "ABC", false)]
        [InlineData("ABC", "", false)]
        [InlineData("abc", "ADc", false)]
        [InlineData("adc", "ABc", false)]
        [InlineData("ABC", "abc", true)]
        [InlineData("abc", "ABC", true)]
        [InlineData("abc", "ABc", true)]
        public void EqualsIgnoreCase_Should_Pass(string source, string target, bool expected)
        {
            source.EqualsIgnoreCase(target).Should().Be(expected);
        }

        [Theory]
        [InlineData(null, "", false)]
        [InlineData("abc", null, false)]
        [InlineData(null, null, true)]
        public void EqualsIgnoreCaseAndNull_Should_Pass_IfBothAreNull(string source, string target, bool expected)
        {
            source.EqualsIgnoreCaseAndNull(target).Should().Be(expected);
        }

        [Fact]
        public void HashIntoGuid_Should_ComputeTheCorrectGuid()
        {
            const string input = "Test_Name";
            Guid expectedOutput = GuidUtils.StringHashIntoGuid(input);

            var result = input.HashIntoGuid();

            result.Should().Be(expectedOutput);
        }
    }
}
