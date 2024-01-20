namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int citiesCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> kvp = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < citiesCount; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string continent = arguments[0];
                string country = arguments[1];
                string city = arguments[2];

                if (!kvp.ContainsKey(continent))
                {
                    kvp.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!kvp[continent].ContainsKey(country))
                {
                    kvp[continent].Add(country, new List<string>());
                }

                kvp[continent][country].Add(city);
            }

            foreach (var continent in kvp.Keys)
            {
                Console.WriteLine($"{continent}:");

                foreach (var country in kvp[continent].Keys)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", kvp[continent][country])}");
                }
            }
        }
    }
}
