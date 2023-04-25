
using Microsoft.AspNetCore.Http;

using NevesCS.AspNetCore.Constants;

namespace NevesCS.AspNetCore.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string? GetUserAgent(this HttpRequest @request)
        {
            return (@request?.Headers[Headers.UserAgent])?.ToString();
        }
    }
}
