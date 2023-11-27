using FluentAssertions;

using NevesCS.Static.Utils;
using NevesCS.Static.Extensions;

namespace NevesCS.Tests.Static
{
    public class GuidUtilsTests
    {
        [Fact]
        public void IsNullOrEmpty_HasNoNullReference()
        {
            Guid? guid1 = Guid.Empty;
            Guid? guid2 = null;
            Guid? guid3 = Guid.NewGuid();

            GuidUtils.IsNullOrEmpty(guid1).Should().Be(true);
            guid1.IsNullOrEmpty().Should().Be(true);

            GuidUtils.IsNullOrEmpty(guid2).Should().Be(true);
            guid2.IsNullOrEmpty().Should().Be(true);

            GuidUtils.IsNullOrEmpty(guid3).Should().Be(false);
            guid3.IsNullOrEmpty().Should().Be(false);
        }

        [Fact]
        public async Task StringHashIntoGuid_Should_ComputeTheCorrectGuid()
        {
            const string input = "Test_Name";
            const string expectedOutput = "7f63491e-3e66-6cc0-157d-a6599d7c65ec";

            GuidUtils.HashStringIntoGuid(input).Should().Be(expectedOutput);
            input.HashStringIntoGuid().Should().Be(expectedOutput);

            (await GuidUtils.HashStringIntoGuidAsync(input)).Should().Be(expectedOutput);
            (await input.HashStringIntoGuidAsync()).Should().Be(expectedOutput);
        }
    }
}
