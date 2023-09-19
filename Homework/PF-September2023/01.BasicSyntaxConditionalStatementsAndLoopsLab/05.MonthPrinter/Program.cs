using System;

namespace _05.MonthPrinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int input = int.Parse(Console.ReadLine());

            // Print output
            if (input == 1) { Console.WriteLine("January"); }
            else if (input == 2) { Console.WriteLine("February"); }
            else if (input == 3) { Console.WriteLine("March"); }
            else if (input == 4) { Console.WriteLine("April"); }
            else if (input == 5) { Console.WriteLine("May"); }
            else if (input == 6) { Console.WriteLine("June"); }
            else if (input == 7) { Console.WriteLine("July"); }
            else if (input == 8) { Console.WriteLine("August"); }
            else if (input == 9) { Console.WriteLine("September"); }
            else if (input == 10) { Console.WriteLine("October"); }
            else if (input == 11) { Console.WriteLine("November"); }
            else if (input == 12) { Console.WriteLine("December"); }
            else { Console.WriteLine("Error!"); }
        }
    }
}
