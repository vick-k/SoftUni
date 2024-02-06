namespace CustomStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;

        private int[] items;
        private int count;

        public CustomStack()
        {
            count = 0;
            items = new int[InitialCapacity];
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public void Push(int item)
        {
            if (count == items.Length)
            {
                Resize();
            }

            items[count] = item;
            count++;
        }

        public int Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int item = items[count - 1];
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
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }

            int item = items[count - 1];

            return item;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
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
