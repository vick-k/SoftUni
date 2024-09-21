namespace _05.GenericCountMethodString
{
    public class Box<T>
    {
        private List<T> box;

        public Box(T element)
        {
            box = new List<T>();
            Value = element;
        }

        public T Value { get; set; }

        public void Add(T element)
        {
            box.Add(element);
        }

        public static int CountGreaterElements(List<Box<T>> list, T element)
        {
            int count = 0;

            Comparer<T> comparer = Comparer<T>.Default;

            foreach (Box<T> box in list)
            {
                if (comparer.Compare(box.Value, element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
