using System;

namespace _04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            // Calculate final minutes and hours
            int finalMinutes = minutes + 30;
            if (finalMinutes > 59)
            {
                hours++;
                finalMinutes -= 60;
            }

            if (hours > 23)
            {
                hours = 0;
            }

            // Print output
            Console.WriteLine($"{hours}:{finalMinutes:d2}");
        }
    }
}
