using System;

namespace _10.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int input = int.Parse(Console.ReadLine());

            // Print output
            int times = 1;
            for (int i = 0; i < 10; i++)
            {
                int result = input * times;

                Console.WriteLine($"{input} X {times} = {result}");
                times++;
            }
        }
    }
}
