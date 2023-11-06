namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> elements = new Dictionary<string, int>();

            foreach (var key in input)
            {
                if (elements.ContainsKey(key))
                {
                    elements[key]++;
                }
                else
                {
                    elements.Add(key, 1);
                }
            }

            foreach (KeyValuePair<string, int> kvp in elements)
            {
                if (kvp.Value % 2 == 1)
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
        }
    }
}