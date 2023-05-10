
using NevesCS.AspNetCore.Abstractions.Interfaces;

using Newtonsoft.Json;

namespace NevesCS.AspNetCore.Adapters
{
    public sealed class NewtonsoftJsonClient : IJsonClientAdapter
    {
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
