using System.Numerics;

using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class INumberDimensionConversionExtensions
    {
        public static T MillimetersToCentimeters<T>(this T value)
            where T : IDivisionOperators<T, int, T>
        {
            return DimensionConversions.MillimetersToCentimeters(value);
        }

        public static T CentimetersToMillimeters<T>(this T value)
            where T : IMultiplyOperators<T, int, T>
        {
            return DimensionConversions.CentimetersToMillimeters(value);
        }
    }
}
