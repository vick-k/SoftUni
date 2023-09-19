using System;

namespace _04.PersonalTitles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            // Print output
            if (gender == "m")
                if (age >= 16)
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Master");
                }
            if (gender == "f")
                if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
        }
    }
}
