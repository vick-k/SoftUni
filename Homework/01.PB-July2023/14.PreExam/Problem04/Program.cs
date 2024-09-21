using System;

namespace Problem04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int days = int.Parse(Console.ReadLine());

            // Calculate the total liters and the average degrees
            double litersTotal = 0;
            double degreesTotal = 0;

            for (int i = 0; i < days; i++)
            {
                double liters = double.Parse(Console.ReadLine());
                double degrees = double.Parse(Console.ReadLine());

                litersTotal += liters;
                degreesTotal += degrees * liters;
            }

            double degreesAverage = degreesTotal / litersTotal;

            // Print output
            Console.WriteLine($"Liter: {litersTotal:f2}");
            Console.WriteLine($"Degrees: {degreesAverage:f2}");

            if (degreesAverage < 38)
            {
                Console.WriteLine($"Not good, you should baking!");
            }
            else if (degreesAverage < 42)
            {
                Console.WriteLine($"Super!");
            }
            else
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}
