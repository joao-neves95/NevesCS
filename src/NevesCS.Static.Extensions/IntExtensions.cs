using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class IntExtensions
    {
        public static bool IsEven(this int value)
        {
            return CalculationUtils.IsEven(value);
        }

        public static int Concat(this int value, int right)
        {
            return CalculationUtils.Concat(value, right);
        }

        public static int DigitCount(this int value)
        {
            return CalculationUtils.DigitCount(value);
        }
    }
}
