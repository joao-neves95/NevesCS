
namespace NevesCS.AspNetCore.Interfaces
{
    /// <summary>
    /// A wrapper to perform Http operations.
    ///
    /// </summary>
    public interface IHttpClientAdapter
    {
        public Task<TResponse?> GetAsync<TResponse>(string endpoint);
    }
}
