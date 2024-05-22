using LanguageExt;

namespace NevesCS.NonStatic.ReferenceTypes
{
    public class DomainResult<T> : DomainResult
    {
        private Option<T> Value { get; set; }

        public bool HasValue => Value.IsSome;

        public Option<T> GetValue()
        {
            return Value;
        }

        public DomainResult<T> SetValue(Option<T> value)
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
