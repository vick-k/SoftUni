using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veggyMeny = int.Parse(Console.ReadLine());

            // Costs
            double chickenMenuPrice = chickenMenu * 10.35;
            double fishMenuPrice = fishMenu * 12.4;
            double veggyMenuPrice = veggyMeny * 8.15;
            double deliveryCost = 2.5;

            // Print output
            double menusCost = chickenMenuPrice + fishMenuPrice + veggyMenuPrice;
            double dessertCost = menusCost * 0.2;
            Console.WriteLine(menusCost + dessertCost + deliveryCost);
        }
    }
}
