using System;

namespace _03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int nonPrimeSum = 0;

            string input = Console.ReadLine();
            while (input != "stop")
            {
                bool isPrime = true;
                int currentNumber = int.Parse(input);
                if (currentNumber < 0)
                {
                    Console.WriteLine($"Number is negative.");
                }
                else
                {
                    for (int i = 2; i < currentNumber && isPrime; i++)
                    {
                        if (currentNumber % i == 0)
                        {
                            isPrime = false;
                        }
                    }

                    if (isPrime)
                    {
                        primeSum += currentNumber;
                    }
                    else
                    {
                        nonPrimeSum += currentNumber;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
