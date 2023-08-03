using FluentAssertions;

using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static.Utils
{
    public class GuidUtilsTests
    {
        [Fact]
        public void StringHashIntoGuid_Should_ComputeTheCorrectGuid()
        {
            const string input = "Test_Name";
            const string expectedOutput = "7f63491e-3e66-6cc0-157d-a6599d7c65ec";

            Guid result = GuidUtils.StringHashIntoGuid(input);

            result.ToString().Should().Be(expectedOutput);
        }
    }
}
