using System;

namespace _02.Passed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double grade = double.Parse(Console.ReadLine());

            // Print output
            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
