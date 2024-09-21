using System.Diagnostics.Metrics;

namespace Problem01
{
    internal class Program // The Hunting Games
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double totalWater = days * players * waterPerDay;
            double totalFood = days * players * foodPerDay;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                energy -= energyLoss;

                if (energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    break;
                }

                if (i % 2 == 0)
                {
                    totalWater -= totalWater * 0.3;
                    energy += energy * 0.05;
                }

                if (i % 3 == 0)
                {
                    totalFood -= totalFood / players;
                    energy += energy * 0.10;
                }
            }

            if (energy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
            }
        }
    }
}