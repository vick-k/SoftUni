using System;

namespace _04.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPrice = double.Parse(Console.ReadLine());
            double fruitsPrice = double.Parse(Console.ReadLine());
            int vegetablesWeight = int.Parse(Console.ReadLine());
            int fruitsWeight = int.Parse(Console.ReadLine());

            double vegetablesCost = vegetablesPrice * vegetablesWeight;
            double fruitsCost = fruitsPrice * fruitsWeight;

            Console.WriteLine($"{(vegetablesCost + fruitsCost) / 1.94:f2}");
        }
    }
}
