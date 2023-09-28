using System;

namespace _10.PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int pokePower = int.Parse(Console.ReadLine()); // N
            int distance = int.Parse(Console.ReadLine()); // M
            int exhaustFactor = int.Parse(Console.ReadLine()); // Y

            // Find the remaining power and poked targets
            int targetsPoked = 0;
            int currentPower = pokePower;
            int halfPower = pokePower / 2;

            while (currentPower >= distance)
            {
                currentPower -= distance;
                targetsPoked++;

                if (currentPower == halfPower && exhaustFactor != 0)
                {
                    currentPower /= exhaustFactor;
                }
            }

            // Print output
            Console.WriteLine(currentPower);
            Console.WriteLine(targetsPoked);
        }
    }
}
