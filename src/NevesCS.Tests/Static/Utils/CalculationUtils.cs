using FluentAssertions;

using NevesCS.Static.Utils;

namespace NevesCS.Tests.Static.Utils
{
    public class CalculationUtilsTests
    {
        [Fact]
        public void IsEven_Passes()
        {
            CalculationUtils.IsEven(1).Should().Be(false);
            CalculationUtils.IsEven(2).Should().Be(true);
            CalculationUtils.IsEven(3).Should().Be(false);
            CalculationUtils.IsEven(4).Should().Be(true);
            CalculationUtils.IsEven(10).Should().Be(true);
            CalculationUtils.IsEven(53).Should().Be(false);
            CalculationUtils.IsEven(54).Should().Be(true);
            CalculationUtils.IsEven(100).Should().Be(true);
        }

        [Fact]
        public void Concat_ConcatenatesTwoNumbers()
        {
            CalculationUtils.Concat(1039, 7056).Should().Be(10397056);
            CalculationUtils.Concat(23, 100).Should().Be(23100);
            CalculationUtils.Concat(200, 23).Should().Be(20023);
        }
    }
}
