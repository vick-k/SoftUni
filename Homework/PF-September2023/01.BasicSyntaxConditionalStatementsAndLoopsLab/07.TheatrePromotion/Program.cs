﻿using System;

namespace _07.TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            // Get ticket price
            int ticketPrice = 0;
            bool invalidAge = false;

            if (day == "Weekday")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    ticketPrice = 12;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 18;
                }
                else
                {
                    invalidAge = true;
                }
            }

            if (day == "Weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    ticketPrice = 15;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 20;
                }
                else
                {
                    invalidAge = true;
                }
            }

            if (day == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    ticketPrice = 5;
                }
                else if (age > 18 && age <= 64)
                {
                    ticketPrice = 12;
                }
                else if (age > 64 && age <= 122)
                {
                    ticketPrice = 10;
                }
                else
                {
                    invalidAge = true;
                }
            }

            // Print output
            if (invalidAge)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{ticketPrice}$");
            }
        }
    }
}
