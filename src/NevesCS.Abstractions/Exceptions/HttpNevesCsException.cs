namespace NevesCS.Abstractions.Exceptions
{
    public class HttpNevesCsException : NevesCsException
    {
        public HttpNevesCsException()
        {
        }

        public HttpNevesCsException(string? message) : base(message)
        {
        }

        public HttpNevesCsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public HttpNevesCsException(HttpResponseMessage message, string? requestContent)
        : base(
              BuildErrorMessage(
                  message?.RequestMessage?.Method?.Method,
                  message?.RequestMessage?.RequestUri.OriginalString,
                  requestContent),
              new HttpRequestException(
                  message?.ReasonPhrase ?? message?.StatusCode.ToString(),
                  null,
                  message?.StatusCode))
        {
        }

        public HttpNevesCsException(HttpMethod httpMethod, Uri requestUri, string? requestContent, Exception? innerException)
            : base(
                  BuildErrorMessage(httpMethod.Method, requestUri.OriginalString, requestContent),
                  innerException)
        {
        }

        public HttpNevesCsException(string httpMethod, string requestUri, string? requestContent, Exception? innerException)
            : base(
                  BuildErrorMessage(httpMethod, requestUri, requestContent),
                  innerException)
        {
        }

        private static string BuildErrorMessage(string httpMethod, string requestUri, string? requestContent)
        {
            return "HTTP REQUEST ERROR" +
                $" - '{httpMethod}'" +
                $" '{requestUri}'"
                + (string.IsNullOrEmpty(requestContent) ? string.Empty : $": '{requestContent}'");
        }
    }
}
