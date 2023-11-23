namespace NevesCS.Static.Utils
{
    public static class CalculationUtils
    {
        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static int Concat(int left, int right)
        {
            return (left * ((int)Math.Pow(10, DigitCount(right)))) + right;
        }

        public static int DigitCount(int value)
        {
            var counter = 1;
            var widthMeter = 10;

            while (widthMeter <= value)
            {
                widthMeter *= 10;
                ++counter;
            }

            return counter;
        }
    }
}
