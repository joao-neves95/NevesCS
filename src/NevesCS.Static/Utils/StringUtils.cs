﻿namespace NevesCS.Static.Utils
{
    public static class StringUtils
    {
        public static bool EqualsIgnoreCase(string source, string target)
        {
            return source?.Equals(target, StringComparison.OrdinalIgnoreCase) == true;
        }

        public static Guid HashIntoGuid(string source)
        {
            return GuidUtils.HashStringIntoGuid(source);
        }
    }
}
