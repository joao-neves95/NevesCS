using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string source, string target)
        {
            return StringUtils.EqualsIgnoreCase(source, target);
        }

        public static Guid HashIntoGuid(this string source)
        {
            return GuidUtils.HashStringIntoGuid(source);
        }
    }
}
