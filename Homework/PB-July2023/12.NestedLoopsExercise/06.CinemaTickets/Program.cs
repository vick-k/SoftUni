using System;

namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ticketsTotal = 0;
            int ticketsStudent = 0;
            int ticketsStandard = 0;
            int ticketsKids = 0;

            string movieName = Console.ReadLine();
            while (movieName != "Finish")
            {
                int ticketsSold = 0;
                int freeSeats = int.Parse(Console.ReadLine());

                for (int i = 0; i < freeSeats; i++)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    if (ticketType == "student")
                    {
                        ticketsStudent++;
                    }
                    else if (ticketType == "standard")
                    {
                        ticketsStandard++;
                    }
                    else if (ticketType == "kid")
                    {
                        ticketsKids++;
                    }

                    ticketsSold++;
                    ticketsTotal++;
                }

                Console.WriteLine($"{movieName} - {100.0 * ticketsSold / freeSeats:f2}% full.");

                movieName = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {ticketsTotal}");
            Console.WriteLine($"{100.0 * ticketsStudent / ticketsTotal:f2}% student tickets.");
            Console.WriteLine($"{100.0 * ticketsStandard / ticketsTotal:f2}% standard tickets.");
            Console.WriteLine($"{100.0 * ticketsKids / ticketsTotal:f2}% kids tickets.");
        }
    }
}
