using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int n = int.Parse(Console.ReadLine());

            // Sum all digits
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;

                int currentNumber = i;
                while (currentNumber > 0)
                {
                    int lastDigit = currentNumber % 10;
                    sum += lastDigit;
                    currentNumber /= 10;
                }

                // Print output
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
