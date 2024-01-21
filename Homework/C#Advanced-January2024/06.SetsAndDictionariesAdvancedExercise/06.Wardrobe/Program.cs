namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clothesCount = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < clothesCount; i++)
            {
                string[] clothing = Console.ReadLine().Split(" -> ");
                string color = clothing[0];
                string[] clothes = clothing[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }

            string[] clothingToFind = Console.ReadLine().Split();
            string clothingColor = clothingToFind[0];
            string clothingType = clothingToFind[1];

            foreach (var clothing in wardrobe)
            {
                Console.WriteLine($"{clothing.Key} clothes:");

                foreach (var type in clothing.Value)
                {
                    if (clothing.Key == clothingColor && type.Key == clothingType)
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value}");
                    }
                }
            }
        }
    }
}
