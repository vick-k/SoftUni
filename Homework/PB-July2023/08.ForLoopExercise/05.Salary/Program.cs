using System;

namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int tabsOpen = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            // Reading the tabs and the fines
            for (int i = 0; i < tabsOpen && salary > 0; i++)
            {
                string site = Console.ReadLine();
                if (site == "Facebook")
                {
                    salary -= 150;
                }
                else if (site == "Instagram")
                {
                    salary -= 100;
                }
                else if (site == "Reddit")
                {
                    salary -= 50;
                }
            }

            // Print output
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
