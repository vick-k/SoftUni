using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int kegsCount = int.Parse(Console.ReadLine());

            // Find the biggest keg
            double biggestKegVolume = 0;
            string biggestKegModel = "";
            for (int i = 0; i < kegsCount; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double kegVolume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;
                if (kegVolume > biggestKegVolume)
                {
                    biggestKegVolume = kegVolume;
                    biggestKegModel = kegModel;
                }
            }

            // Print output
            Console.WriteLine(biggestKegModel);
        }
    }
}
