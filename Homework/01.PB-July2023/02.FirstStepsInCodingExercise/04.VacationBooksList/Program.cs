using System;

namespace _04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysNeeded = int.Parse(Console.ReadLine());

            // Calculations
            int readingTime = pages / pagesPerHour;
            int hoursNeeded = readingTime / daysNeeded;

            // Print output
            Console.WriteLine(hoursNeeded);
        }
    }
}
