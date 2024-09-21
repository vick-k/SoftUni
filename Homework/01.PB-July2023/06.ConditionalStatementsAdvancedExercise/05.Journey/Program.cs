using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            // Determine the destination
            string destination = "";
            double stayExpenses = 0;
            string sleepPlace = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    stayExpenses = budget * 0.3;
                }
                else if (season == "winter")
                {
                    stayExpenses = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    stayExpenses = budget * 0.4;
                }
                else if (season == "winter")
                {
                    stayExpenses = budget * 0.8;
                }
            }
            else
            {
                destination = "Europe";
                stayExpenses = budget * 0.9;
            }
            if (season == "summer" && destination != "Europe")
            {
                sleepPlace = "Camp";
            }
            else
            {
                sleepPlace = "Hotel";
            }

            // Print output
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{sleepPlace} - {stayExpenses:f2}");
        }
    }
}
