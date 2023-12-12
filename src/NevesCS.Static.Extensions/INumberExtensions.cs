#if NET7_0_OR_GREATER
using System.Numerics;
#endif

using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class INumberExtensions
    {
#if NET7_0_OR_GREATER
        public static T Add<T>(this T left, T right)
            where T : INumber<T>
        {
            return CalculationUtils.Add(left, right);
        }

        public static T Subtract<T>(this T left, T right)
            where T : INumber<T>
        {
            return CalculationUtils.Subtract(left, right);
        }

        public static T Multiply<T>(this T left, T right)
            where T : INumber<T>
        {
            return CalculationUtils.Multiply(left, right);
        }

        public static T Divide<T>(this T left, T right)
            where T : INumber<T>
        {
            return CalculationUtils.Divide(left, right);
        }

        public static decimal SafeAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
            where TSource : struct, INumber<TSource>
        {
            return CalculationUtils.SafeAverage(source, selector);
        }
#else
        public static decimal SafeAverage<T>(this IEnumerable<T> enumeration, Func<T, decimal> selector)
            where T : struct, IComparable
        {
            return CalculationUtils.SafeAverage(enumeration, selector);
        }
#endif
    }
}
