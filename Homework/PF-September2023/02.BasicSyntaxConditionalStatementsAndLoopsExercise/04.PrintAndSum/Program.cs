using System;

namespace _04.PrintAndSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            // Print numbers
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }

            // Print sum
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
