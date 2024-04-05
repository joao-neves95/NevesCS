using FluentAssertions;

using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;
using NevesCS.Tests.Mocks;

namespace NevesCS.Tests.Static
{
    public class IEnumerableUtilsTests
    {
        [Fact]
        public void ForEach_Should_ActForEachItem()
        {
            int[] input = { 0, 1, 2, 3, 4, 5, 6 };

            int i = 0;
            IEnumerableUtils.ForEach(input, num => num.Should().Be(i++));

            i = 0;
            input.ForEach(num => num.Should().Be(i++));
        }

        [Fact]
        public void ContainsObjectValue_Should_()
        {
            string[] allElements = { "nop", "nop", "nop", "HERE", "nop", "nop" };
            MockClass mockClass = new() { UselessString = "HERE" };

            IEnumerableUtils.ContainsObjectValue(allElements, mockClass, mock => mock.UselessString).Should().BeTrue();
            allElements.ContainsObjectValue(mockClass, mock => mock.UselessString).Should().BeTrue();
        }
    }
}
