using NevesCS.Abstractions.Clients;
using NevesCS.NonStatic.Patterns;

namespace NevesCS.NonStatic.Clients
{
    /// <summary>
    /// This is an Http Client that caches IPs in order to bypass DNS lookups.
    ///
    /// </summary>
    public sealed class CachedIpHttpClient : INevesHttpClient
    {
        public CachedIpHttpClient()
        {
            var temp = new HttpClient();
        }
    }
}
