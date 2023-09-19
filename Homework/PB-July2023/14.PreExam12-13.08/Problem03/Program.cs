using System;

namespace Problem03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double packetWeight = double.Parse(Console.ReadLine());
            string serviceType = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());

            double pricePerOneKilometer = 0;
            double overchargeTotal = 0;
            
            // Find the price per kilometer and calculate the overcharge
            if (serviceType == "standard")
            {
                if (packetWeight < 1)
                {
                    pricePerOneKilometer = 0.03;
                }
                else if (packetWeight < 10)
                {
                    pricePerOneKilometer = 0.05;
                }
                else if (packetWeight < 40)
                {
                    pricePerOneKilometer = 0.10;
                }
                else if (packetWeight < 90)
                {
                    pricePerOneKilometer = 0.15;
                }
                else
                {
                    pricePerOneKilometer = 0.20;
                }
            }
            else if (serviceType == "express")
            {
                if (packetWeight < 1)
                {
                    pricePerOneKilometer = 0.03;
                    overchargeTotal = packetWeight * distance * pricePerOneKilometer * 0.80;
                }
                else if (packetWeight < 10)
                {
                    pricePerOneKilometer = 0.05;
                    overchargeTotal = packetWeight * distance * pricePerOneKilometer * 0.40;
                }
                else if (packetWeight < 40)
                {
                    pricePerOneKilometer = 0.10;
                    overchargeTotal = packetWeight * distance * pricePerOneKilometer * 0.05;
                }
                else if (packetWeight < 90)
                {
                    pricePerOneKilometer = 0.15;
                    overchargeTotal = packetWeight * distance * pricePerOneKilometer * 0.02;
                }
                else
                {
                    pricePerOneKilometer = 0.20;
                    overchargeTotal = packetWeight * distance * pricePerOneKilometer * 0.01;
                }
            }

            // Print output
            double totalCost = (pricePerOneKilometer * distance) + overchargeTotal;

            Console.WriteLine($"The delivery of your shipment with weight of {packetWeight:f3} kg. would cost {totalCost:f2} lv.");
        }
    }
}
