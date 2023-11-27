using NevesCS.Static.Constants;

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace NevesCS.Static.Utils
{
    public static class CalculationUtils
    {
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
