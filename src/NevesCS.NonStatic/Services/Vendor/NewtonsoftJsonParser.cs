using NevesCS.Abstractions.Services;

using Newtonsoft.Json;

namespace NevesCS.NonStatic.Services.Vendor
{
    public sealed class NewtonsoftJsonParser : IJsonParser
    {
        public string? SerializeObject(object source)
        {
            return JsonConvert.SerializeObject(source);
        }

        public TResult? DeserializeObject<TResult>(string jsonString)
        {
            return JsonConvert.DeserializeObject<TResult>(jsonString);
        }

        public TResult? DeserializeStream<TResult>(Stream jsonStream)
        {
            if (jsonStream is null)
            {
                return default;
            }

            using var sr = new StreamReader(jsonStream);
            using JsonReader reader = new JsonTextReader(sr);

            return new JsonSerializer().Deserialize<TResult>(reader);
        }
    }
}
