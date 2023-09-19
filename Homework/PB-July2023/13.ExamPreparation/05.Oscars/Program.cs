using System;

namespace _05.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double initialPoints = double.Parse(Console.ReadLine());
            int judgesCount = int.Parse(Console.ReadLine());

            double totalPoints = initialPoints;
            bool enoughPoints = false;

            for (int i = 0; i < judgesCount; i++)
            {
                string judgeName = Console.ReadLine();
                double points = double.Parse(Console.ReadLine());

                double givenPoints = judgeName.Length * points / 2.0;

                totalPoints += givenPoints;

                if (totalPoints > 1250.5)
                {
                    enoughPoints = true;
                    break;
                }
            }

            if (enoughPoints)
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
