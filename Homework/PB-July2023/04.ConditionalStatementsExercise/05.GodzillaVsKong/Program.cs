using System;

namespace _05.GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input

            double budged = double.Parse(Console.ReadLine());
            int extraActors = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            // Calculations

            double decorPrice = budged * 0.1;

            double totalClothingPrice = extraActors * clothingPrice;

            if (extraActors > 150)
            {
                totalClothingPrice = extraActors * clothingPrice * 0.9;
            }

            // Print output

            if (budged >= decorPrice + totalClothingPrice)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budged - (decorPrice + totalClothingPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(decorPrice + totalClothingPrice) - budged:F2} leva more.");
            }
        }
    }
}
