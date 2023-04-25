
namespace NevesCS.Static.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string source, string target)
        {
            return source?.Equals(target, StringComparison.OrdinalIgnoreCase) == true;
        }
    }
}
