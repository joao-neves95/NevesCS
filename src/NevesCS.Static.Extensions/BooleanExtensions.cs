using NevesCS.Static.Utils;

namespace NevesCS.Static.Extensions
{
    public static class BooleanExtensions
    {
        public static bool IsTrue(this bool? target)
        {
            return BooleanUtils.IsTrue(target);
        }
    }
}
