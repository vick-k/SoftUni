using System;

namespace _01.ExcellentResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double grade = double.Parse(Console.ReadLine());

            // Print output
            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
