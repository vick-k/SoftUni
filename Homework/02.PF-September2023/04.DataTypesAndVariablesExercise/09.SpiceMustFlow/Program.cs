using System;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int startingYield = int.Parse(Console.ReadLine());

            // Find the total spice and days operated
            int totalSpice = 0;
            int daysOperated = 0;

            while (startingYield >= 100)
            {
                totalSpice += startingYield - 26;
                startingYield -= 10;
                daysOperated++;
            }

            if (totalSpice >= 26)
            {
                totalSpice -= 26;
            }

            // Print output
            Console.WriteLine(daysOperated);
            Console.WriteLine(totalSpice);
        }
    }
}
