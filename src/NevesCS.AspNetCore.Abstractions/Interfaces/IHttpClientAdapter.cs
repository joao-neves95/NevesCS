
namespace NevesCS.AspNetCore.Abstractions.Interfaces
{
    /// <summary>
    /// A wrapper to perform Http operations.
    ///
    /// </summary>
    public interface IHttpClientAdapter
    {
        public Task<TResponse?> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default);
    }
}
