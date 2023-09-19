using System;

namespace Problem06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int locationsCount = int.Parse(Console.ReadLine());

            // Read the rest of the input and find the average mined gold per location
            for (int i = 0; i < locationsCount; i++)
            {
                double averageMinedGoldPerDay = double.Parse(Console.ReadLine());
                int currentLocationDays = int.Parse(Console.ReadLine());

                double totalMinedGold = 0;

                for (int j = 0; j < currentLocationDays; j++)
                {
                    double minedGold = double.Parse(Console.ReadLine());
                    totalMinedGold += minedGold;
                }

                double averageMinedGold = totalMinedGold / (1.0 * currentLocationDays);

                if (averageMinedGold >= averageMinedGoldPerDay)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageMinedGold:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {averageMinedGoldPerDay - averageMinedGold:f2} gold.");
                }
            }
        }
    }
}
