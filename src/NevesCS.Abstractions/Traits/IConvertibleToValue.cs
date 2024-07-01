namespace NevesCS.Abstractions.Traits
{
    public interface IConvertibleToValue<out TOut>
    {
        public TOut ToValue();
    }
}
