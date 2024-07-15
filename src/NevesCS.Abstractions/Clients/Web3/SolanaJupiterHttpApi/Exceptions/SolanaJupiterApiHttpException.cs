using NevesCS.Abstractions.Exceptions;

namespace NevesCS.Abstractions.Clients.Web3.SolanaJupiterHttpApi.Exceptions
{
    public class SolanaJupiterApiHttpException : HttpNevesCsException
    {
        public SolanaJupiterApiHttpException() : base()
        {
        }

        public SolanaJupiterApiHttpException(string? message) : base(message)
        {
        }

        public SolanaJupiterApiHttpException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public SolanaJupiterApiHttpException(HttpResponseMessage message, string? requestContent) : base(message, requestContent)
        {
        }

        public SolanaJupiterApiHttpException(HttpMethod httpMethod, Uri requestUri, string? requestContent, Exception? innerException)
            : base(httpMethod, requestUri, requestContent, innerException)
        {
        }

        public SolanaJupiterApiHttpException(string httpMethod, string requestUri, string? requestContent, Exception? innerException)
            : base(httpMethod, requestUri, requestContent, innerException)
        {
        }
    }
}
