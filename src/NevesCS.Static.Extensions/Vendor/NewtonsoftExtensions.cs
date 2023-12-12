using NevesCS.Abstractions.Options;
using NevesCS.Abstractions.Traits;
using NevesCS.Static.Utils.Vendor;

using Newtonsoft.Json;

namespace NevesCS.Static.Extensions.Vendor
{
    public static class NewtonsoftExtensions
    {
        public static string ToJson(this object @target, JsonIdentation identation = JsonIdentation.None)
        {
            return NewtonsoftUtils.ToJson(@target, identation);
        }

        public static string ToJson(this IJsonSerializable @target, JsonIdentation identation = JsonIdentation.None)
        {
            return NewtonsoftUtils.ToJson(@target, identation);
        }

        public static Formatting ToNewtonsoftFormatting(this JsonIdentation jsonIdentation)
        {
            return NewtonsoftUtils.ToNewtonsoftFormatting(jsonIdentation);
        }
    }
}
