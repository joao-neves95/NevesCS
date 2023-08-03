using Newtonsoft.Json;

namespace NevesCS.AspNetCore.Extensions
{
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Deserializes <see cref="HttpResponseMessage.Content"/> into an object. <br />
        /// Throws if <see cref="HttpResponseMessage.IsSuccessStatusCode"/> is <see cref="false"/>.
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public static async Task<T?> ReadContentAs<T>(this HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.ReasonPhrase,
                    null,
                    response.StatusCode);
            }

            var dataAsString = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(dataAsString);
        }
    }
}
