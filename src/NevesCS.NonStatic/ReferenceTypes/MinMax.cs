namespace NevesCS.NonStatic.ReferenceTypes
{
    public class MinMaxValue<T>
    {
        public MinMaxValue(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public T Min { get; set; }

        public T Max { get; set; }
    }
}
