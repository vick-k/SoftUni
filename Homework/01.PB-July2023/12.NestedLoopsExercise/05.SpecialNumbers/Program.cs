using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                bool specialNum = true;
                int currentNum = i;
                while (currentNum != 0)
                {
                    int firstDigit = currentNum % 10;
                    if (firstDigit != 0 && n % firstDigit == 0)
                    {
                        currentNum /= 10;
                    }
                    else
                    {
                        specialNum = false;
                        break;
                    }
                }

                if (specialNum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
