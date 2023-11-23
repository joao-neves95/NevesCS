using NevesCS.Static.Extensions;
using NevesCS.Static.Utils;

using FluentAssertions;

namespace NevesCS.Tests.Static.Utils
{
    public class CalculationUtilsTests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(53, false)]
        [InlineData(54, true)]
        [InlineData(100, true)]
        public void IsEven_Passes(int input, bool expected)
        {
            CalculationUtils.IsEven(input).Should().Be(expected);
            input.IsEven().Should().Be(expected);
        }

        [Theory]
        [InlineData(1039, 7056, 10397056)]
        [InlineData(23, 100, 23100)]
        [InlineData(200, 23, 20023)]
        public void Concat_ConcatenatesTwoNumbers(int left, int right, int expected)
        {
            CalculationUtils.Concat(left, right).Should().Be(expected);
            left.Concat(right).Should().Be(expected);
        }

        [Theory]
        [InlineData(10397056, 8)]
        [InlineData(1039, 4)]
        [InlineData(200, 3)]
        [InlineData(23, 2)]
        [InlineData(9, 1)]
        [InlineData(0, 1)]
        public void DigitCount_CountsNumberOfDigits(int input, int expected)
        {
            CalculationUtils.DigitCount(input).Should().Be(expected);
            input.DigitCount().Should().Be(expected);
        }
    }
}
