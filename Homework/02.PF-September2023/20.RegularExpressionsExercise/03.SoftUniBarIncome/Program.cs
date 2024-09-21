using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+|\d+\.\d+)\$";

            double income = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    continue;
                }

                string name = match.Groups["name"].Value;
                string product = match.Groups["product"].Value;
                double totalPrice = int.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value);

                income += totalPrice;

                Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
