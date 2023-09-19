using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int length = int.Parse(Console.ReadLine()); // In cm
            int width = int.Parse(Console.ReadLine()); // In cm
            int height = int.Parse(Console.ReadLine()); // In cm
            double takenPercentage = double.Parse(Console.ReadLine());

            // Calculations
            int volume = length * width * height; // In cubic cm
            double convertedVolume = volume * 0.001; // In liters

            // Print output
            Console.WriteLine(convertedVolume - (convertedVolume * takenPercentage * 0.01));
        }
    }
}
