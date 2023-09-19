using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input

            double worldRecordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double secondsPerOneMeter = double.Parse(Console.ReadLine());

            // Caclulations

            double neededTimeInSeconds = distanceInMeters * secondsPerOneMeter;
            double slowDownTimes = Math.Floor(distanceInMeters / 15);
            double slowedTimeInSeconds = slowDownTimes * 12.5;
            double totalTime = neededTimeInSeconds + slowedTimeInSeconds;

            // Print output

            if (totalTime >= worldRecordInSeconds)
            {
                Console.WriteLine($"No, he failed! He was {totalTime - worldRecordInSeconds:F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
        }
    }
}
