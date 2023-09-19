using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string month = Console.ReadLine();
            int daysCount = int.Parse(Console.ReadLine());

            //Define the price per day and the total price without discount
            double pricePerDayStudio = 0;
            double pricePerDayApartment = 0;
            double priceWithoutDiscountStudio = 0;
            double priceWithoutDiscountApartment = 0;

            if (month == "May" ||  month == "October")
            {
                pricePerDayStudio = 50;
                pricePerDayApartment = 65;
            }
            else if (month == "June" || month == "September")
            {
                pricePerDayStudio = 75.20;
                pricePerDayApartment = 68.70;
            }
            else if (month == "July" || month == "August")
            {
                pricePerDayStudio = 76;
                pricePerDayApartment = 77;
            }

            priceWithoutDiscountStudio = daysCount * pricePerDayStudio;
            priceWithoutDiscountApartment = daysCount * pricePerDayApartment;

            // Calculate the discount and the final price
            double priceTotalStudio = priceWithoutDiscountStudio;
            double priceTotalApartment = priceWithoutDiscountApartment;

            if (daysCount > 7 && daysCount <= 14 && (month == "May" || month == "October"))
            {
                priceTotalStudio = priceWithoutDiscountStudio * 0.95;
            }
            else if (daysCount > 14 && (month == "May" || month == "October"))
            {
                priceTotalStudio = priceWithoutDiscountStudio * 0.7;
            }
            else if (daysCount > 14 && (month == "June" || month == "September"))
            {
                priceTotalStudio = priceWithoutDiscountStudio * 0.8;
            }
            if (daysCount > 14)
            {
                priceTotalApartment = priceWithoutDiscountApartment * 0.9;
            }

            // Print output
            Console.WriteLine($"Apartment: {priceTotalApartment:f2} lv.");
            Console.WriteLine($"Studio: {priceTotalStudio:f2} lv.");
        }
    }
}
