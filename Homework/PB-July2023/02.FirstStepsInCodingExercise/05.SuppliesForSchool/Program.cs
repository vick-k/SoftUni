using System;

namespace _05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int cleaningStuff = int.Parse(Console.ReadLine());
            int discountPercentage = int.Parse(Console.ReadLine());

            // Print output
            double price = (pens * 5.8 + markers * 7.2 + cleaningStuff * 1.2);
            Console.WriteLine(price - (price * discountPercentage * 0.01));
        }
    }
}
