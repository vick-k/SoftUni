using System;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string flowerType = Console.ReadLine();
            int flowersCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            // Calculating the flowers price
            double flowersPrice = 0;

            if (flowerType == "Roses")
            {
                if (flowersCount <= 80)
                {
                    flowersPrice = flowersCount * 5;
                }
                else
                {
                    flowersPrice = flowersCount * 5 * 0.9;
                }
            }
            else if (flowerType == "Dahlias")
            {
                if (flowersCount <= 90)
                {
                    flowersPrice = flowersCount * 3.80;
                }
                else
                {
                    flowersPrice = flowersCount * 3.80 * 0.85;
                }
            }
            else if (flowerType == "Tulips")
            {
                if (flowersCount <= 80)
                {
                    flowersPrice = flowersCount * 2.80;
                }
                else
                {
                    flowersPrice = flowersCount * 2.80 * 0.85;
                }
            }
            else if (flowerType == "Narcissus")
            {
                if (flowersCount >= 120)
                {
                    flowersPrice = flowersCount * 3;
                }
                else
                {
                    flowersPrice = flowersCount * 3 * 1.15;
                }
            }
            else if (flowerType == "Gladiolus")
            {
                if (flowersCount >= 80)
                {
                    flowersPrice = flowersCount * 2.50;
                }
                else
                {
                    flowersPrice = flowersCount * 2.50 * 1.20;
                }
            }

            // Print output
            if (budget >= flowersPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersCount} {flowerType} and {budget - flowersPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {flowersPrice - budget:f2} leva more.");
            }
        }
    }
}
