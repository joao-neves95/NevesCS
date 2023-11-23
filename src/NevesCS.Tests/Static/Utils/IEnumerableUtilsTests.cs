using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static.Utils
{
    public class IEnumerableUtilsTests
    {
        [Fact]
        public void ForEach_Should_ActForEachItem()
        {
            int[] input = { 0, 1, 2, 3, 4, 5, 6 };

            int i = 0;
            IEnumerableUtils.ForEach(input, elem => elem.Should().Be(i++));

            i = 0;
            input.ForEach(elem => elem.Should().Be(i++));
        }
    }
}
