
namespace NevesCS.Static.Extensions
{
    public static class BooleanExtensions
    {
        public static bool IsTrue(this bool? target)
        {
            return target == true;
        }
    }
}
