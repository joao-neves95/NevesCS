namespace NevesCS.Static.Utils
{
    public static class CalculationUtils
    {
        public static bool IsEven(int value)
        {
            return value % Ints.Two == Ints.Zero;
        }

        public static int Concat(int left, int right)
        {
            return (left * ((int)Math.Pow(Ints.Ten, DigitCount(right)))) + right;
        }

        public static int DigitCount(int value)
        {
            var counter = Ints.One;
            var widthMeter = Ints.Ten;

            while (widthMeter <= value)
            {
                widthMeter *= Ints.Ten;
                ++counter;
            }

            return counter;
        }
    }
}
