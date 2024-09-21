using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int diluent = int.Parse(Console.ReadLine());
            int hoursNeeed = int.Parse(Console.ReadLine());

            // Prices
            double nylonPrice = (nylon + 2) * 1.5;
            double paintPrice = paint * 1.1 * 14.5;
            double diluentPrice = diluent * 5;
            double bagsPrice = 0.4;

            // Print output
            double materialsCost = nylonPrice + paintPrice + diluentPrice + bagsPrice;
            double workCost = materialsCost * 0.3 * hoursNeeed;
            Console.WriteLine(materialsCost + workCost);
        }
    }
}
