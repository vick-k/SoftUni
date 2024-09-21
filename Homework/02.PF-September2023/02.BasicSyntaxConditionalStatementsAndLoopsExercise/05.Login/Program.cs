using System;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string username = Console.ReadLine();

            // Find the correct password
            string correctPassword = "";

            int length = username.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                char currentChar = username[i];
                correctPassword += currentChar;
            }

            // Checking the password and print outputs
            int count = 0;

            while (count < 4)
            {
                string password = Console.ReadLine();

                if (password != correctPassword && count < 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else if (password == correctPassword)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }

                count++;
            }

            if (count > 3)
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
