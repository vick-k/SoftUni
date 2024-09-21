using System.Text.RegularExpressions;

namespace Problem02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());

            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<string>[A-Za-z]{8,})\]";

            for (int i = 0; i < inputsCount; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    Console.WriteLine($"The message is invalid");
                    continue;
                }

                string stringToTranslate = match.Groups["string"].Value;

                List<int> numbersList = new List<int>();

                foreach (char character in stringToTranslate)
                {
                    numbersList.Add(character);
                }

                string command = match.Groups["command"].Value;

                Console.WriteLine($"{command}: {string.Join(" ", numbersList)}");
            }
        }
    }
}
