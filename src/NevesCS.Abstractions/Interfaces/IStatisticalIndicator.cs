namespace NevesCS.Abstractions.Interfaces
{
    public interface IStatisticalIndicator
    {
        public void AddSample(decimal item);

        public decimal Compute(decimal newSample);

        public decimal Compute();
    }
}
