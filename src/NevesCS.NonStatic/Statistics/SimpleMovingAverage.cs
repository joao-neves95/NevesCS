using NevesCS.Abstractions.Interfaces;
using NevesCS.NonStatic.Constants;
using NevesCS.Static.Constants;

namespace NevesCS.NonStatic.Statistics
{
    public class SimpleMovingAverage : IStatisticalIndicator
    {
        private readonly LinkedList<decimal> Data = new();

        private decimal Total = Ints.Zero;
        private int SampleSize = 21;

        public void SetSampleSize(int sampleSize)
        {
            if (sampleSize <= Ints.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(sampleSize), $"{nameof(sampleSize)} must be higher than 0.");
            }

            SampleSize = sampleSize;
        }

        public void AddSample(decimal item)
        {
            if (Data.First == null)
            {
                throw new InvalidOperationException(ErrorMessages.CollectionEmpty);
            }

            if (Data.Count == SampleSize)
            {
                Total -= Data.First!.Value;
                Data.RemoveFirst();
            }

            Total += item;
            Data.AddLast(item);
        }

        public decimal Compute(decimal newSample)
        {
            AddSample(newSample);
            return Compute();
        }

        public decimal Compute()
        {
            return Total / Data.Count;
        }
    }
}
