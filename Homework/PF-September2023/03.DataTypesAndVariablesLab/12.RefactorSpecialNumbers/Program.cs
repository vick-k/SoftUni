using System;

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int number = 1; number <= input; number++)
            {
                int sum = 0;
                int currentNumber = number;
                while (number > 0)
                {
                    sum += number % 10;
                    number = number / 10;
                }

                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", currentNumber, isSpecial);

                number = currentNumber;
            }
        }
    }
}
