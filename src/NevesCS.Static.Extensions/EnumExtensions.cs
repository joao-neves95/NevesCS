using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumValue)
            where T : Enum
        {
            return EnumUtils.GetDescription(enumValue);
        }
    }
}
