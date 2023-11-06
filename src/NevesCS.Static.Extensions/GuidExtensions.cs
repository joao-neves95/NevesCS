using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsNullOrEmpty(this Guid? guid)
        {
            return GuidUtils.IsNullOrEmpty(guid);
        }
    }
}
