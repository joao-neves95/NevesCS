using Microsoft.Extensions.Options;

using NevesCS.AspNetCore.Abstractions.Interfaces;
using NevesCS.AspNetCore.Abstractions.Models.Configuration;
using NevesCS.Static.Extensions;

using Polly;

namespace NevesCS.AspNetCore.Adapters
{
    public sealed class DotnetHttpClient : IHttpClientAdapter
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonClientAdapter _jsonClient;

        private readonly TimeSpan[] _sleepDurationPolicy;

        public DotnetHttpClient(
            IOptions<HttpConfig> appConfig,
            HttpClient httpClient,
            IJsonClientAdapter jsonClient)
        {
            _httpClient = httpClient.ThrowIfNull();
            _jsonClient = jsonClient.ThrowIfNull();

            _sleepDurationPolicy = GetSleepDurationPolicy(appConfig.ThrowIfNull().Value.NumberOfHttpRetries).ToArray();
        }

        public async Task<TResponse?> GetAsync<TResponse>(string endpoint)
        {
            if (endpoint is null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            var pollyResponse = await Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(_sleepDurationPolicy)
                .ExecuteAndCaptureAsync(async () => await _httpClient.GetStreamAsync(endpoint));

            if (pollyResponse.FinalException is not null)
            {
                throw pollyResponse.FinalException;
            }

            var result = _jsonClient.DeserializeStream<TResponse?>(pollyResponse.Result);
            await pollyResponse.Result.DisposeAsync();

            return result;
        }

        private static IEnumerable<TimeSpan> GetSleepDurationPolicy(int numberOfRetries)
        {
            for (var i = 1; i <= numberOfRetries; ++i)
            {
                yield return TimeSpan.FromSeconds(i);
            }
        }
    }
}
