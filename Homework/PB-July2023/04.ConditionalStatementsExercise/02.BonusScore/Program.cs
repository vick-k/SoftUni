using System;

namespace _02.BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            
            int score = int.Parse(Console.ReadLine());

            // Additional bonus points

            int additionalBonusPoints = 0;

            if (score % 2 == 0)
            {
                additionalBonusPoints = additionalBonusPoints + 1;
            }
            else if (score % 10 == 5)
            {
                additionalBonusPoints = additionalBonusPoints + 2;
            }

            // Print output

            if (score <= 100)
            {
                int bonusPoints = 5;
                Console.WriteLine(bonusPoints + additionalBonusPoints);
                Console.WriteLine(score + bonusPoints + additionalBonusPoints);
            }
            else if (score <= 1000)
            {
                double bonusPoints = 0.2 * score;
                Console.WriteLine(bonusPoints + additionalBonusPoints);
                Console.WriteLine(score + bonusPoints + additionalBonusPoints);
            }
            else if (score > 1000)
            {
                double bonusPoints = 0.1 * score;
                Console.WriteLine(bonusPoints + additionalBonusPoints);
                Console.WriteLine(score + bonusPoints + additionalBonusPoints);
            }
        }
    }
}
