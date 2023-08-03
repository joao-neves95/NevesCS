using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCaseAndNull(this string source, string target)
        {
            if (source == default && target == default)
            {
                return true;
            }

            return source?.EqualsIgnoreCase(target) == true;
        }

        public static bool EqualsIgnoreCase(this string source, string target)
        {
            return source?.Equals(target, StringComparison.OrdinalIgnoreCase) == true;
        }

        public static Guid HashIntoGuid(this string source)
        {
            return GuidUtils.StringHashIntoGuid(source);
        }
    }
}
