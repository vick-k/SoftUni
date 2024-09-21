using System;

namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int peopleCount = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            // Find the courses
            int courses = (int)Math.Ceiling((double)peopleCount / elevatorCapacity);

            // Print output
            Console.WriteLine(courses);
        }
    }
}
