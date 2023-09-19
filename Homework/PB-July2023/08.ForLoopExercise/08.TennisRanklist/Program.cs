using System;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int tournamentsCount = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());

            // Finding the average points, final points and won tournaments
            int finalPoints = initialPoints;
            int wonTournaments = 0;

            for (int i = 0; i < tournamentsCount; i++)
            {
                string place = Console.ReadLine();

                if (place == "W")
                {
                    finalPoints += 2000;
                    wonTournaments++;
                }
                else if (place == "F")
                {
                    finalPoints += 1200;
                }
                else
                {
                    finalPoints += 720;
                }
            }
            int averagePoints = (finalPoints - initialPoints) / tournamentsCount;

            // Print output
            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{100.0 * wonTournaments / tournamentsCount:f2}%");
        }
    }
}
