using System;

namespace Problem01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int groupSize = int.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            int transportCardsCount = int.Parse(Console.ReadLine());
            int museumTicketsCount = int.Parse(Console.ReadLine());

            // Calculate the cost (without discount)
            int nightsCost = nightsCount * 20;
            double transportCardsCost = transportCardsCount * 1.60;
            int museumTicketsCost = museumTicketsCount * 6;

            // Calculate the cost per person and for the whole group
            double totalCostPerPerson = nightsCost + transportCardsCost + museumTicketsCost;
            double totalCostForGroup = groupSize * totalCostPerPerson;

            // Calculate the total cost (with discount)
            double totalCost = totalCostForGroup * 1.25;

            // Print output
            Console.WriteLine($"{totalCost:f2}");
        }
    }
}
