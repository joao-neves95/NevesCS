namespace NevesCS.NonStatic.Models.Exceptions
{
    public class NevesCsException : Exception
    {
        public NevesCsException() : base()
        {
        }

        public NevesCsException(string? message) : base(message)
        {
        }

        public NevesCsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
