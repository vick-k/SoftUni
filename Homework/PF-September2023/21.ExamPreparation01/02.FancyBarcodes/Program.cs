using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int barcodesCount = int.Parse(Console.ReadLine());

            string patternBarcode = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
            string patternDigit = @"\d";

            for (int i = 0; i < barcodesCount; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, patternBarcode);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                MatchCollection digitsCollection = Regex.Matches(barcode, patternDigit);

                if (digitsCollection.Count == 0)
                {
                    Console.WriteLine("Product group: 00");
                    continue;
                }

                string productGroup = "";

                foreach (Match digit in digitsCollection)
                {
                    productGroup += digit.Value;
                }
                
                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}
