using System;

namespace _01.StudentInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());

            // Print output
            Console.WriteLine($"Name: {name}, Age: {age}, Grade: {grade:f2}");
        }
    }
}
