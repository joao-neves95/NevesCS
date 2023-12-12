namespace NevesCS.Static.Extensions
{
    public static class DoubleExtensions
    {
        public static double ToThePowerOf(this double target, int exponent)
        {
            return Math.Pow(target, exponent);
        }
    }
}
