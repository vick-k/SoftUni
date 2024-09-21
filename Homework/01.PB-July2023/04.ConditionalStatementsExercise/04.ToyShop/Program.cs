using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input

            double tourPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            // Toys prices

            double puzzlesPrice = 2.60;
            double dollsPrice = 3;
            double bearsPrice = 4.10;
            double minionsPrice = 8.20;
            double trucksPrice = 2;

            // Calculations

            double totalToysCost = puzzles * puzzlesPrice + dolls * dollsPrice + bears * bearsPrice + minions * minionsPrice + trucks * trucksPrice;
            int totalToysCount = puzzles + dolls + bears + minions + trucks;

            // Print output

            if (totalToysCount >= 50)
            {
                totalToysCost = totalToysCost - totalToysCost * 0.25;
            }
            
            totalToysCost = totalToysCost - totalToysCost * 0.10;

            if (totalToysCost >= tourPrice)
            {
                Console.WriteLine($"Yes! {totalToysCost - tourPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tourPrice - totalToysCost:F2} lv needed.");
            }
        }
    }
}