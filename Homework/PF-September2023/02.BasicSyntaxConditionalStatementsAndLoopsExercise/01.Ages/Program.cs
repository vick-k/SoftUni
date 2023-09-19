using System;

namespace _01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int age = int.Parse(Console.ReadLine());

            // Determine the type of person
            string person = "";
            if (age <= 2)
            {
                person = "baby";
            }
            else if (age <= 13)
            {
                person = "child";
            }
            else if (age <= 19)
            {
                person = "teenager";
            }
            else if (age <= 65)
            {
                person = "adult";
            }
            else
            {
                person = "elder";
            }

            // Print output
            Console.WriteLine(person);
        }
    }
}
