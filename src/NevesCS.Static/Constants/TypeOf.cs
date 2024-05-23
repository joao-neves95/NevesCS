using System.Diagnostics.CodeAnalysis;

namespace NevesCS.Static.Constants
{
    [ExcludeFromCodeCoverage]
    public static class TypeOf
    {
        public static readonly Type String = typeof(string);

        public static readonly Type Int = typeof(int);
        public static readonly Type Float = typeof(float);
        public static readonly Type Decimal = typeof(decimal);
    }
}
