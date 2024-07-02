using NevesCS.Abstractions.Exceptions;

namespace NevesCS.Abstractions.Clients.Web3.DexTools.Exceptions
{
    public class DexToolsApiHttpException : HttpNevesCsException
    {
        public DexToolsApiHttpException() : base()
        {
        }

        public DexToolsApiHttpException(string? message) : base(message)
        {
        }

        public DexToolsApiHttpException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public DexToolsApiHttpException(HttpResponseMessage message, string? requestContent) : base(message, requestContent)
        {
        }

        public DexToolsApiHttpException(HttpMethod httpMethod, Uri requestUri, string? requestContent, Exception? innerException)
            : base(httpMethod, requestUri, requestContent, innerException)
        {
        }

        public DexToolsApiHttpException(string httpMethod, string requestUri, string? requestContent, Exception? innerException)
            : base(httpMethod, requestUri, requestContent, innerException)
        {
        }
    }
}
