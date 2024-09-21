using System;

namespace _10.InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int num = int.Parse(Console.ReadLine());

            // Print output
            if (!(num >= 100 && num <= 200 || num == 0))
            {
                Console.WriteLine("invalid");
            }

            // Solution using bool
            //bool isValid = num >= 100 && num <= 200 || num == 0;
            //if (!isValid)
            //{
            //    Console.WriteLine("invalid");
            //}
        }
    }
}
