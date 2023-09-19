using System;

namespace _02.MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeForOneMeterInSeconds = double.Parse(Console.ReadLine());

            double climbingTime = distanceInMeters * timeForOneMeterInSeconds;
            double slowdownTime = Math.Floor(distanceInMeters / 50.0) * 30;

            double totalTime = climbingTime + slowdownTime;

            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {totalTime - recordInSeconds:f2} seconds slower.");
            }
        }
    }
}
