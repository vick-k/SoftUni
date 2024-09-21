using System;

namespace _09.LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int multiplier = int.Parse(Console.ReadLine());

            // Finding the sum of the numbers
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < 2 * multiplier; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i < multiplier)
                {
                    sum1 += num;
                }
                else
                {
                    sum2 += num;
                }
            }

            // Print output
            if (sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum1 - sum2)}");
            }
        }
    }
}
