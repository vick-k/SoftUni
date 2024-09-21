using System;

namespace _10.OddEvenSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int numCount = int.Parse(Console.ReadLine());

            // Finding the odd sum and even sum
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 1; i <= numCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddSum += num;
                }
                else
                {
                    evenSum += num;
                }
            }

            // Print output
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {oddSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(oddSum - evenSum)}");
            }
        }
    }
}
