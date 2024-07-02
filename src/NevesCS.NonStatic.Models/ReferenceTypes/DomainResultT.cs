namespace NevesCS.NonStatic.ReferenceTypes
{
    public class DomainResult<T> : DomainResult
    {
        private T? Value { get; set; }

        public bool HasValue => Value is not null;

        public T? GetValue()
        {
            return Value;
        }

        public DomainResult<T> SetValue(T value)
        {
            Value = value;

            return this;
        }

        public new DomainResult<T> Combine(DomainResult result)
        {
            base.Combine(result);

            return this;
        }
    }
}
