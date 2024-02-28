using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Tests.Mocks;

namespace NevesCS.Tests.Static
{
    public class FuncUtilsTests
    {
        [Fact]
        public void Enumerate_Should_EnumerateTheResultsOfAFactoryXTimes()
        {
            int id = 1;

            var factory = () => new DataGame() { AppId = id++ };

            factory.Enumerate(0).ToArray().Length.Should().Be(0);

            id = 1;
            factory.Enumerate(1).ToArray().Length.Should().Be(1);

            id = 1;
            factory.Enumerate(3).ToArray().Length.Should().Be(3);

            id = 1;
            var result = factory.Enumerate(10).ToArray();
            result.Length.Should().Be(10);

            for (int i = 0; i < 10; ++i)
            {
                result[i].AppId.Should().Be(i + 1);
            }
        }
    }
}
