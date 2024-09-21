using System;
using System.Dynamic;

namespace _02.WeekendOrWorkingDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string day = Console.ReadLine();

            // Print output
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    Console.WriteLine("Working day");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
