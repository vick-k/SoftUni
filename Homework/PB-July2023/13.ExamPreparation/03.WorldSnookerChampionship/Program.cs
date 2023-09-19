using System;

namespace _03.WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string round = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsCount = int.Parse(Console.ReadLine());
            char trophyPicture = char.Parse(Console.ReadLine());

            double ticketPrice = 0;
            if (round == "Quarter final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 55.50;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 105.20;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 118.90;
                }
            }
            else if (round == "Semi final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 75.88;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 125.22;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 300.40;
                }
            }
            else if (round == "Final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 110.10;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 160.66;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 400;
                }
            }

            double totalTicketsPrice = ticketPrice * ticketsCount;

            double discount;

            if (totalTicketsPrice <= 2500)
            {
                discount = 1;
            }
            else if (totalTicketsPrice <= 4000)
            {
                discount = 0.90;
            }
            else
            {
                discount = 0.75;
            }

            if (trophyPicture == 'Y' && totalTicketsPrice <= 4000)
            {
                Console.WriteLine($"{totalTicketsPrice * discount + (ticketsCount * 40):f2}");
            }
            else
            {
                Console.WriteLine($"{totalTicketsPrice * discount:f2}");
            }
        }
    }
}
