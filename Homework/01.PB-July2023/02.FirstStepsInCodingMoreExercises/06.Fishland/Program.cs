using System;

namespace _06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mackerelPrice = double.Parse(Console.ReadLine()); // скумрия
            double sprinklePrice = double.Parse(Console.ReadLine()); // цаца
            double bonitoWeight = double.Parse(Console.ReadLine()); // паламуд
            double scadWeight = double.Parse(Console.ReadLine()); // сафрид
            int musselsWeight = int.Parse(Console.ReadLine()); // миди

            // Find the total price for bonito, scad and mussels
            double bonitoTotalCost = bonitoWeight * mackerelPrice * 1.6;
            double scadTotalCost = scadWeight * sprinklePrice * 1.8;
            double musselsTotalCost = musselsWeight * 7.5;

            Console.WriteLine($"{bonitoTotalCost + scadTotalCost + musselsTotalCost:f2}");
        }
    }
}
