namespace NevesCS.NonStatic.Models.ValueTypes
{
    public struct MinMaxValue<T>
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
