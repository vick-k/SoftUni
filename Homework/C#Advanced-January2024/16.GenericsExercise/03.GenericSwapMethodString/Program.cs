namespace _03.GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = int.Parse(Console.ReadLine());

            List<string> list = new();

            for (int i = 0; i < stringsCount; i++)
            {
                string input = Console.ReadLine();
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
