using System;

namespace _02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int number = int.Parse(Console.ReadLine());

            // Find the last digit and the total sum
            int sum = 0;
            while (number > 0)
            {
                int lastDigit = number % 10;
                sum += lastDigit;
                number /= 10;
            }

            // Print output
            Console.WriteLine(sum);
        }
    }
}
