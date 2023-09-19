using System;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int number = int.Parse(Console.ReadLine());

            // Find the factorials and the total sum
            int sum = 0;

            int currentNumber = number;
            while (currentNumber > 0)
            {
                int lastDigit = currentNumber % 10;

                int factorial = 1;
                while (lastDigit > 0)
                {
                    factorial *= lastDigit;
                    lastDigit--;
                }

                sum += factorial;
                currentNumber /= 10;
            }

            // Print output
            if (number == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
