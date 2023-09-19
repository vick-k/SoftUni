using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            // Check if password is correct
            string enteredPassword = Console.ReadLine();
            while (enteredPassword != password)
            {
                enteredPassword = Console.ReadLine();
            }

            // Print output
            Console.WriteLine($"Welcome {username}!");
        }
    }
}
