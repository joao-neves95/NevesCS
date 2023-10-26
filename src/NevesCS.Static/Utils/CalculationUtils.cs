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
            int rightLength = 10;

            while (rightLength <= right)
            {
                rightLength *= 10;
            }

            return (left * rightLength) + right;
        }
    }
}
