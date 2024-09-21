using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string favoriteBook = Console.ReadLine();

            // Finding the favorite book
            int checkedBooks = 0;
            string book = Console.ReadLine();
            while (book != "No More Books")
            {
                if (book == favoriteBook)
                {
                    Console.WriteLine($"You checked {checkedBooks} books and found it.");
                    break;
                }

                checkedBooks++;
                book = Console.ReadLine();
            }

            // Print negative output
            if (book != favoriteBook)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {checkedBooks} books.");
            }
        }
    }
}
