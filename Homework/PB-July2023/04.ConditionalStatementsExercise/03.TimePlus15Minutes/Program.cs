using System;

namespace _03.TimePlus15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input

            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            // Calculations

            int convertedHoursToMinutes = hours * 60;
            int additionalMinutes = 15;

            int totalTime = convertedHoursToMinutes + minutes + additionalMinutes;

            int calculatedTotalHours = totalTime / 60;

            if (calculatedTotalHours > 23)
            {
                calculatedTotalHours = 0;
            }

            // Print output

            if (totalTime % 60 < 10)
            {
                Console.WriteLine($"{calculatedTotalHours}:0{totalTime % 60}");
            }
            else
            {
                Console.WriteLine($"{calculatedTotalHours}:{totalTime % 60}");
            }
        }
    }
}
