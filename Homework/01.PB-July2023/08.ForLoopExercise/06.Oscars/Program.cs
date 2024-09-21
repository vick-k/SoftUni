using System;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string actorName = Console.ReadLine();
            double initialPoints = double.Parse(Console.ReadLine());
            int judgesCount = int.Parse(Console.ReadLine());

            // Calculating the points
            double totalPoints = initialPoints;
            for (int i = 0; i < judgesCount && totalPoints <= 1250.5; i++)
            {
                string judgeName = Console.ReadLine();
                double judgeScore = double.Parse(Console.ReadLine());

                judgeScore = judgeName.Length * judgeScore / 2;
                totalPoints += judgeScore;
            }

            // Print output
            if (totalPoints >= 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {totalPoints:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - totalPoints:f1} more!");
            }
        }
    }
}
