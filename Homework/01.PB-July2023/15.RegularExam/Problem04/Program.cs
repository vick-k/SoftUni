using System;

namespace Problem04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int catsCount = int.Parse(Console.ReadLine());

            // Categorize cats and find the total eaten food
            double foodPricePerOneKilogram = 12.45;
            double totalEatenFoodInGrams = 0;
            
            int smallCatsCount = 0;
            int largeCatsCount = 0;
            int hugeCatsCount = 0;

            for (int i = 0; i < catsCount; i++)
            {
                double foodEatenInGrams = double.Parse(Console.ReadLine());

                if (foodEatenInGrams < 200)
                {
                    smallCatsCount++;
                }
                else if (foodEatenInGrams < 300)
                {
                    largeCatsCount++;
                }
                else
                {
                    hugeCatsCount++;
                }

                totalEatenFoodInGrams += foodEatenInGrams;
            }

            // Print output
            Console.WriteLine($"Group 1: {smallCatsCount} cats.");
            Console.WriteLine($"Group 2: {largeCatsCount} cats.");
            Console.WriteLine($"Group 3: {hugeCatsCount} cats.");
            Console.WriteLine($"Price for food per day: {totalEatenFoodInGrams / 1000.0 * foodPricePerOneKilogram:f2} lv.");
        }
    }
}
