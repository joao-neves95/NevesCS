using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class StringExtensions
    {
        public static string CloneIntoNew(this string source)
        {
            return new string(source);
        }

        public static bool EqualsIgnoreCase(this string? source, string target)
        {
            return StringUtils.EqualsIgnoreCase(source, target);
        }

        public static Guid HashStringIntoGuid(this string source)
        {
            return GuidUtils.HashStringIntoGuid(source);
        }

        public static async Task<Guid> HashStringIntoGuidAsync(this string source)
        {
            return await GuidUtils.HashStringIntoGuidAsync(source);
        }
    }
}
