namespace CustomQueue
{
    public class CustomQueue
    {
        private const int InitialCapacity = 4;
        private const int FirstItemIndex = 0;

        private int[] items;
        private int count;

        public CustomQueue()
        {
            count = 0;
            items = new int[InitialCapacity];
        }

        public int Count => count;

        public void Enqueue(int item)
        {
            if (count == items.Length)
            {
                Resize();
            }

            items[count] = item;
            count++;
        }

        public int Dequeue()
        {
            IsEmpty();

            int item = items[FirstItemIndex];
            ShiftLeft(FirstItemIndex);
            items[count - 1] = default;
            count--;

            if (count <= items.Length / 2 && items.Length != 4)
            {
                Shrink();
            }

            return item;
        }

        public int Peek()
        {
            IsEmpty();

            int item = items[FirstItemIndex];

            return item;
        }

        public void Clear()
        {
            IsEmpty();

            int[] newArr = new int[InitialCapacity];
            items = newArr;
            count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }

        private void IsEmpty()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
    }
}
