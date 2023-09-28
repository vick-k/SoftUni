using System;

namespace _04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int n = int.Parse(Console.ReadLine());

            // Find the sum of the characters
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                totalSum += letter;
            }

            // Print output
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
