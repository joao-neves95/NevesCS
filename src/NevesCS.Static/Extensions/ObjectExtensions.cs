
namespace NevesCS.Static.Extensions
{
    public static class ObjectExtensions
    {
        public static T ThrowIfNull<T>(this T? @object)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(typeof(T).Name);
            }

            return @object;
        }

        public static string Serialize(this object @obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(@obj);
        }
    }
}
