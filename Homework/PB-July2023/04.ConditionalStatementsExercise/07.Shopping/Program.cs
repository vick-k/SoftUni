using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double budget = double.Parse(Console.ReadLine());
            int videoCard = int.Parse(Console.ReadLine());
            int cpu = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            // Calculate products costs
            double videoCardCost = 250;
            double cpuCost = videoCard * videoCardCost * 0.35;
            double ramCost = videoCard * videoCardCost * 0.10;

            // Calculate total cost
            double totalCost = 0;

            if (videoCard > cpu)
            {
                totalCost = (videoCard * videoCardCost + cpu * cpuCost + ram * ramCost) * 0.85;
            }
            else
            {
                totalCost = videoCard * videoCardCost + cpu * cpuCost + ram * ramCost;
            }

            // Print output
            if (budget >= totalCost)
            {
                Console.WriteLine($"You have {budget - totalCost:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalCost - budget:F2} leva more!");
            }
        }
    }
}
