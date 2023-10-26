
namespace NevesCS.Static.Extensions.Vendor
{
    public static class NewtonsoftExtensions
    {
        public static string Serialize(this object @obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(@obj);
        }
    }
}
