using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return EnumUtils.GetDescription(enumValue);
        }
    }
}
