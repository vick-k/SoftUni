using System;

namespace _05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            int corridorWidth = 100;
            int workPlaceWidth = 70;
            int workPlaceLength = 120;

            double desksInRow = Math.Floor((width * 100 - corridorWidth) / workPlaceWidth);
            double rows = Math.Floor(length * 100 / workPlaceLength);

            Console.WriteLine($"{desksInRow * rows - 3}");
        }
    }
}
