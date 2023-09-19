using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int daysStay = int.Parse(Console.ReadLine());
            string placeType = Console.ReadLine();
            string rating = Console.ReadLine();


            // Finding the price for each place type
            int nightsStay = daysStay - 1;
            double priceForAllNights = 0;

            if (placeType == "room for one person")
            {
                priceForAllNights = nightsStay * 18;
            }
            else if (placeType == "apartment")
            {
                if (daysStay < 10)
                {
                    priceForAllNights = nightsStay * 25 * 0.7;
                }
                else if (daysStay <= 15)
                {
                    priceForAllNights = nightsStay * 25 * 0.65;
                }
                else
                {
                    priceForAllNights = nightsStay * 25 * 0.5;
                }
            }
            else
            {
                if (daysStay < 10)
                {
                    priceForAllNights = nightsStay * 35 * 0.9;
                }
                else if (daysStay <= 15)
                {
                    priceForAllNights = nightsStay * 35 * 0.85;
                }
                else
                {
                    priceForAllNights = nightsStay * 35 * 0.8;
                }
            }

            // Calculating the tip
            if (rating == "positive")
            {
                priceForAllNights = priceForAllNights * 1.25;
            }
            else
            {
                priceForAllNights = priceForAllNights * 0.9;
            }

            // Print output
            Console.WriteLine($"{priceForAllNights:f2}");
        }
    }
}
