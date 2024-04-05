using NevesCS.Static.Constants;

using System.Numerics;

namespace NevesCS.Static.Utils
{
    public static class CalculationUtils
    {
        /// <summary>
        /// Computes the average and returns 0 in case the source is null or empty (does not throw).
        ///
        /// </summary>
        public static decimal SafeAverage<T>(IEnumerable<T> source, Func<T, decimal> selector)
            where T : INumber<T>
        {
            return source?.Any() != true
                ? 0
                : source.Average(selector);
        }

        public static bool IsEven(int value)
        {
            return value % Ints.Two == Ints.Zero;
        }

        /// <summary>
        /// Returns the percentage representation in 0-100 format.
        ///
        /// </summary>
        public static decimal Percentage(decimal part, decimal total)
        {
            return (part * Ints.OneHundred) / total;
        }

        /// <summary>
        /// Returns the percentage representation in 0-1 format.
        ///
        /// </summary>
        public static decimal FractionalPercentage(decimal part, decimal total)
        {
            return Percentage(part, total) / Ints.OneHundred;
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

        public static T Add<T>(T left, T right)
            where T : INumber<T>
        {
            return left + right;
        }

        public static T Subtract<T>(T left, T right)
            where T : INumber<T>
        {
            return left - right;
        }

        public static T Multiply<T>(T left, T right)
            where T : INumber<T>
        {
            return left * right;
        }

        public static T Divide<T>(T left, T right)
            where T : INumber<T>
        {
            return left / right;
        }
    }
}
