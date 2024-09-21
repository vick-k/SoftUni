using System;

namespace _11.MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int input = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            // Check the multiplier and print the output
            int result = input * multiplier;

            if (multiplier > 10)
            {
                Console.WriteLine($"{input} X {multiplier} = {result}");
            }

            while (multiplier <= 10)
            {
                result = input * multiplier;
                Console.WriteLine($"{input} X {multiplier} = {result}");
                multiplier++;
            }
        }
    }
}
