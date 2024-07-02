namespace NevesCS.Abstractions.Traits
{
    public interface IConvertible<out TOut>
    {
        public TOut To<Out>();
    }
}
