using System;

namespace _02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;
            bool isEven = true;

            for (int i = firstNum; i <= secondNum; i++)
            {
                int currentNum = i;
                while (currentNum != 0)
                {
                    int firstDigit = currentNum % 10;
                    if (isEven)
                    {
                        evenSum += firstDigit;
                    }
                    else
                    {
                        oddSum += firstDigit;
                    }
                    isEven = !isEven;
                    currentNum /= 10;
                }

                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
                evenSum = 0;
                oddSum = 0;
            }
        }
    }
}
