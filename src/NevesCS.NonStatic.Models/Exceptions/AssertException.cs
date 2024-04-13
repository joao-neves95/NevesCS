namespace NevesCS.NonStatic.Models.Exceptions
{
    // TODO: Improve this class.
    public class AssertException : NevesCsException
    {
        public AssertException() : base()
        {
        }

        public AssertException(string? message) : base(message)
        {
        }

        public AssertException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public AssertException(string? message, string explanation)
            : base($"{explanation}{(string.IsNullOrEmpty(message) ? string.Empty : $" - {message}")}")
        {
        }

        public static string BuildNotEqualExplanation<TLeft, TRight>(TLeft? left, TRight? right)
        {
            return $"{nameof(left)}('{left}') != {nameof(right)}('{right})'";
        }
    }
}
