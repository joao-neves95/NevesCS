
//using CSharpFunctionalExtensions;

//namespace NevesCS.NonStatic.ReferenceTypes
//{
//    public class DomainResult<T> : DomainResult
//    {
//        private Maybe<T> Value { get; set; }

//        public bool HasValue => Value.HasValue;

//        public Maybe<T> GetValue()
//        {
//            return Value;
//        }

//        public DomainResult<T> SetValue(Maybe<T> value)
//        {
//            Value = value;

//            return this;
//        }

//        public new DomainResult<T> Combine(Result result)
//        {
//            base.Combine(result);

//            return this;
//        }

//        public new DomainResult<T> Combine(DomainResult migrationResultDto)
//        {
//            base.Combine(migrationResultDto);

//            return this;
//        }
//    }
//}
