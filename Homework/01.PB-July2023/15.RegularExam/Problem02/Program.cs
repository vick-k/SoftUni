using System;

namespace Problem02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int beersCount = int.Parse(Console.ReadLine());
            int chipsCount = int.Parse(Console.ReadLine());

            // Calculate the costs
            double beerPrice = 1.20;
            double chipsPrice = beersCount * beerPrice * 0.45;

            double beersCostTotal = beersCount * beerPrice;
            double chipsCostTotal = Math.Ceiling(chipsCount * chipsPrice);

            double costTotal = beersCostTotal + chipsCostTotal;

            // Print output
            if (budget >= costTotal)
            {
                Console.WriteLine($"{name} bought a snack and has {budget - costTotal:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {costTotal - budget:f2} more leva!");
            }
        }
    }
}
