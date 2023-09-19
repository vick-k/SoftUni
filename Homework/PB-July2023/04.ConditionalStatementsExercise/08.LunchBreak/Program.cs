using System;
using System.Text.RegularExpressions;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string seriesName = Console.ReadLine();
            int seriesLength = int.Parse(Console.ReadLine());
            int breakLength = int.Parse(Console.ReadLine());

            // Calculations
            double lunchLength = breakLength / 8.0;
            double relaxLength = breakLength / 4.0;
            double totalLength = seriesLength + lunchLength + relaxLength;

            // Print output
            if (breakLength >= seriesLength + lunchLength + relaxLength)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(breakLength - totalLength)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(totalLength - breakLength)} more minutes.");
            }
        }
    }
}
