using System;

namespace _03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int num = int.Parse(Console.ReadLine());

            // Finding the sum of the numbers
            int sum = 0;
            while (num > sum)
            {
                int currentNum = int.Parse(Console.ReadLine());
                sum += currentNum;
            }

            // Print output
            Console.WriteLine(sum);
        }
    }
}
