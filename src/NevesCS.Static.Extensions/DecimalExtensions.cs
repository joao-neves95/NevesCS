using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns the percentage representation in 0-100 format.
        ///
        /// </summary>
        public static decimal PercentageOf(this decimal part, decimal total)
        {
            return CalculationUtils.Percentage(part, total);
        }

        /// <summary>
        /// Returns the percentage representation in 0-1 format.
        ///
        /// </summary>
        public static decimal FractionalPercentageOf(this decimal part, decimal total)
        {
            return CalculationUtils.FractionalPercentage(part, total);
        }
    }
}
