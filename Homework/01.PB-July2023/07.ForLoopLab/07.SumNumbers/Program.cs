using System;

namespace _07.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int numCount = int.Parse(Console.ReadLine());

            // Print output
            int sum = 0;
            for (int i = 1; i <= numCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
