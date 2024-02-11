using System.Collections;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] items;
        private int count;

        public CustomStack()
        {
            count = 0;
            items = new T[InitialCapacity];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Push(T item)
        {
            if (count == items.Length)
            {
                Resize();
            }

            items[count] = item;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }

            T item = items[count - 1];
            items[count - 1] = default;
            count--;

            if (count <= items.Length / 2 && items.Length != 4)
            {
                Shrink();
            }

            return item;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            T item = items[count - 1];

            return item;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

        private void Resize()
        {
            T[] copy = new T[items.Length * 2];

            for (int i = 0; i < count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[items.Length / 2];

            for (int i = 0; i < count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
