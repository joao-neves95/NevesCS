using NevesCS.Static.Constants;

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace NevesCS.Static.Utils
{
    public static class CalculationUtils
    {
        /// <summary>
        /// Computes the average and returns 0 in case the source is null or empty (does not throw).
        ///
        /// </summary>
        public static decimal SafeAverage<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
            where TSource : struct, IComparable
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
            return (part * 100) / total;
        }

        /// <summary>
        /// Returns the percentage representation in 0-1 format.
        ///
        /// </summary>
        public static decimal FractionalPercentage(decimal part, decimal total)
        {
            return Percentage(part, total) / 100;
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

#if NET7_0_OR_GREATER

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

#endif
    }
}
