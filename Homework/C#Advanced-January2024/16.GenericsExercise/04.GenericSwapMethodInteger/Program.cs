namespace _04.GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int intCount = int.Parse(Console.ReadLine());

            List<int> list = new();

            for (int i = 0; i < intCount; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(input);
            }

            int[] command = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = command[0];
            int secondIndex = command[1];

            Swap(list, firstIndex, secondIndex);
        }

        public static void Swap<T>(List<T> values, int firstIndex, int secondIndex)
        {
            var temp = values[firstIndex];
            values[firstIndex] = values[secondIndex];
            values[secondIndex] = temp;

            foreach (T value in values)
            {
                Console.WriteLine($"{typeof(T)}: {value}");
            }
        }
    }
}
