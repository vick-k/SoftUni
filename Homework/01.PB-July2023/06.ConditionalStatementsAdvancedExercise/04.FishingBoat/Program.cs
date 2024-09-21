using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermenCount = int.Parse(Console.ReadLine());

            // Finding boat price with the discount
            double boatPrice = 0;

            if (season == "Spring")
            {
                if (fishermenCount <= 6)
                {
                    boatPrice = 3000 * 0.9;
                }
                else if (fishermenCount <= 11)
                {
                    boatPrice = 3000 * 0.85;
                }
                else
                {
                    boatPrice = 3000 * 0.75;
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                if (fishermenCount <= 6)
                {
                    boatPrice = 4200 * 0.9;
                }
                else if (fishermenCount <= 11)
                {
                    boatPrice = 4200 * 0.85;
                }
                else
                {
                    boatPrice = 4200 * 0.75;
                }
            }
            else if (season == "Winter")
            {
                if (fishermenCount <= 6)
                {
                    boatPrice = 2600 * 0.9;
                }
                else if (fishermenCount <= 11)
                {
                    boatPrice = 2600 * 0.85;
                }
                else
                {
                    boatPrice = 2600 * 0.75;
                }
            }

            // Calculating the additional discount
            if (fishermenCount % 2 == 0 && season != "Autumn")
            {
                boatPrice = boatPrice * 0.95;
            }

            // Print output
            if (budget >= boatPrice)
            {
                Console.WriteLine($"Yes! You have {budget - boatPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {boatPrice - budget:f2} leva.");
            }
        }
    }
}
