using System;

namespace _03.EvenOrOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int num = int.Parse(Console.ReadLine());

            // Print output
            if (num % 2 ==0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }

        }
    }
}
