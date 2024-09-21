using System;

namespace _09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());

            double singleSquareCost = 7.61;
            double discount = 0.18;

            double areaCost = area * singleSquareCost;
            double discountedCost = areaCost * discount;
            double finalCost = areaCost - discountedCost;

            Console.WriteLine($"The final price is: {finalCost} lv.");
            Console.WriteLine($"The discount is: {discountedCost} lv.");
        }
    }
}
