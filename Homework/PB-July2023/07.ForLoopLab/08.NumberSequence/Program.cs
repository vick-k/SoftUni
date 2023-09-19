using System;

namespace _08.NumberSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int numCount = int.Parse(Console.ReadLine());

            // Finding the smallest and biggest number
            int smallest = int.MaxValue;
            int biggest = int.MinValue;
            for (int i = 0; i < numCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > biggest)
                {
                    biggest = num;
                }
                if (num < smallest)
                {
                    smallest = num;
                }
            }

            // Print output
            Console.WriteLine($"Max number: {biggest}");
            Console.WriteLine($"Min number: {smallest}");
        }
    }
}
