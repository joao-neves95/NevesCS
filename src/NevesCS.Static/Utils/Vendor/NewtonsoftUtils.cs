using NevesCS.Abstractions.Options;
using NevesCS.Abstractions.Traits;

using Newtonsoft.Json;

namespace NevesCS.Static.Utils.Vendor
{
    public static class NewtonsoftUtils
    {
        public static string ToJson(object @target, JsonIdentation identation = JsonIdentation.None)
        {
            return JsonConvert.SerializeObject(
                @target,
                ToNewtonsoftFormatting(identation));
        }

        public static string ToJson(IJsonSerializable @target, JsonIdentation identation = JsonIdentation.None)
        {
            return ToJson(@target.GetJsonObject(), identation);
        }

        public static Formatting ToNewtonsoftFormatting(JsonIdentation jsonIdentation)
        {
            return jsonIdentation switch
            {
                JsonIdentation.Indented => Formatting.Indented,
                JsonIdentation.None => Formatting.None,

                _ => throw new NotSupportedException()
            };
        }
    }
}
