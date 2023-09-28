using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int n = int.Parse(Console.ReadLine());

            // Find the total water
            int totalWater = 0;
            for (int i = 0; i < n; i++)
            {
                int water = int.Parse(Console.ReadLine());
                totalWater += water;

                if (totalWater > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalWater -= water;
                }
            }

            // Print output
            Console.WriteLine(totalWater);
        }
    }
}
