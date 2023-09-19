using System;
using System.Diagnostics;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            // Find the single person price
            double singlePersonPrice = 0;
            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    singlePersonPrice = 8.45;
                }
                else if (day == "Saturday")
                {
                    singlePersonPrice = 9.8;
                }
                else if (day == "Sunday")
                {
                    singlePersonPrice = 10.46;
                }
            }
            else if (groupType == "Business")
            {
                if (day == "Friday")
                {
                    singlePersonPrice = 10.9;
                }
                else if (day == "Saturday")
                {
                    singlePersonPrice = 15.6;
                }
                else if (day == "Sunday")
                {
                    singlePersonPrice = 16;
                }
            }
            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    singlePersonPrice = 15;
                }
                else if (day == "Saturday")
                {
                    singlePersonPrice = 20;
                }
                else if (day == "Sunday")
                {
                    singlePersonPrice = 22.5;
                }
            }

            double totalPrice = peopleCount * singlePersonPrice;
            
            // Calculate discount and Print output
            double discountedPrice = 0;
            if (groupType == "Students" && peopleCount >= 30)
            {
                discountedPrice = totalPrice * 0.85;
                Console.WriteLine($"Total price: {discountedPrice:f2}");
            }
            else if (groupType == "Business" && peopleCount >= 100)
            {
                discountedPrice = (peopleCount - 10) * singlePersonPrice;
                Console.WriteLine($"Total price: {discountedPrice:f2}");
            }
            else if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20)
            {
                discountedPrice = totalPrice * 0.95;
                Console.WriteLine($"Total price: {discountedPrice:f2}");
            }
            else
            {
                Console.WriteLine($"Total price: {totalPrice:f2}");
            }
        }
    }
}
