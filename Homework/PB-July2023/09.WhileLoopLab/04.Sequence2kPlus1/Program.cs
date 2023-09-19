using System;

namespace _04.Sequence2kPlus1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int num = int.Parse(Console.ReadLine());

            // Printing and increasing the current number
            int currentNum = 1;
            while (currentNum <= num)
            {
                Console.WriteLine(currentNum);
                currentNum = currentNum * 2 + 1;
            }
        }
    }
}
