using System;

namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int n = int.Parse(Console.ReadLine());

            // Sum odd numbers
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i * 2 - 1);
                sum += (i * 2 - 1);
            }

            // Print output
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
