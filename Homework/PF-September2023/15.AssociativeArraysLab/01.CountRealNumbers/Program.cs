namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int, int> pairs = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (pairs.ContainsKey(number))
                {
                    pairs[number]++;
                }
                else
                {
                    pairs.Add(number, 1);
                }
            }

            foreach (KeyValuePair<int, int> kvp in pairs)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}