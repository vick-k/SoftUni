using System;

namespace _03.AnimalType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string animal = Console.ReadLine();

            // Print output
            switch (animal)
            {
                case "dog":
                    Console.WriteLine("mammal");
                    break;
                case "crocodile":
                case "tortoise":
                case "snake":
                    Console.WriteLine("reptile");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
