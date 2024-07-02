using System.Collections;

namespace NevesCS.NonStatic.Collections
{
    public class FixedLengthAutoDequeue<T> : IEnumerable<T>
    {
        private readonly uint FixedSize;

        private readonly LinkedList<T> Data = new();

        public FixedLengthAutoDequeue(uint fixedSize)
        {
            FixedSize = fixedSize;
        }

        public FixedLengthAutoDequeue(uint fixedSize, IEnumerable<T> initValues)
        {
            FixedSize = fixedSize;

            foreach (var value in initValues)
            {
                Data.AddLast(value);
            }
        }

        public int Count()
        {
            return Data.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Data).GetEnumerator();
        }

        public IEnumerable<T> AsEnumerable()
        {
            return Data.AsEnumerable();
        }

        public void Enqueue(T newItem)
        {
            if (Data.Count == FixedSize)
            {
                Data.RemoveFirst();
            }

            Data.AddLast(newItem);
        }

        public void Clear()
        {
            Data.Clear();
        }

        public T? Peek()
        {
            return Data.LastOrDefault();
        }
    }
}
