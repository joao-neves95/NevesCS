using NevesCS.AspNetCore.Abstractions.Interfaces;

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
        public static async Task<T?> ReadContentAsAsync<T>(this HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            var dataAsString = await response.ReadContentAsStringAsync(cancellationToken);

            if (dataAsString == null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(dataAsString);
        }

        /// <summary>
        /// Deserializes <see cref="HttpResponseMessage.Content"/> into an object. <br />
        /// Throws if <see cref="HttpResponseMessage.IsSuccessStatusCode"/> is <see cref="false"/>.
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <param name="jsonClient"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public static async Task<T?> ReadContentAsAsync<T>(
            this HttpResponseMessage response,
            IJsonClientAdapter jsonClient,
            CancellationToken cancellationToken = default)
        {
            var dataAsString = await response.ReadContentAsStringAsync(cancellationToken);

            if (dataAsString == null)
            {
                return default;
            }

            return jsonClient.DeserializeObject<T>(dataAsString);
        }

        private static async Task<string?> ReadContentAsStringAsync(this HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    response.ReasonPhrase,
                    null,
                    response.StatusCode);
            }

            return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
