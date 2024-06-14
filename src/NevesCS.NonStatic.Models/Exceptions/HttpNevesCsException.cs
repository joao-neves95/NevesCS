namespace NevesCS.NonStatic.Models.Exceptions
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
                  $"ERROR HTTP REQUEST" +
                  $" - '{message?.RequestMessage?.Method?.Method}'" +
                  $" '{message?.RequestMessage?.RequestUri}'"
                  + (string.IsNullOrEmpty(requestContent) ? string.Empty : $": '{requestContent}'"),
                  new HttpRequestException(
                      message?.ReasonPhrase ?? message?.StatusCode.ToString(),
                      null,
                      message?.StatusCode))
        {
        }
    }
}
