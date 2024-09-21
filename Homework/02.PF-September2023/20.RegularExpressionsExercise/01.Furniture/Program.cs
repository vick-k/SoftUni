using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> validFurniture = new List<string>();
            decimal totalPrice = 0;

            string pattern = @">>(?<furnitureName>[A-Za-z]+)<<(?<price>\d+\.\d+|\d+)!(?<quantity>\d+)";

            Regex regex = new Regex(pattern);

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success == false)
                {
                    continue;
                }

                validFurniture.Add(match.Groups["furnitureName"].Value);

                totalPrice += decimal.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
            }

            Console.WriteLine("Bought furniture:");

            if (validFurniture.Count > 0) // one of the tests fails in judge without this check
            {
                Console.WriteLine(string.Join("\n", validFurniture));
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
