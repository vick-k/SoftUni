using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int annualFee = int.Parse(Console.ReadLine());

            // Calculations
            double shoes = annualFee - (annualFee * 0.4);
            double clothes = shoes - (shoes * 0.2);
            double ball = clothes * 0.25;
            double accessories = ball * 0.2;

            // Print output
            Console.WriteLine(annualFee + shoes + clothes + ball + accessories);
        }
    }
}
