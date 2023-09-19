using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string name = Console.ReadLine();

            //Checking the grades
            double totalGrade = 0.0;
            int currentGrade = 1;
            int badGrades = 0;

            while (currentGrade < 13)
            {
                double yearGrade = double.Parse(Console.ReadLine());

                if (yearGrade < 4.0)
                {
                    badGrades++;
                    if (badGrades == 2)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    totalGrade += yearGrade;

                    currentGrade++;
                }
            }

            // Print output
            if (badGrades < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {totalGrade / 12:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {currentGrade} grade");
            }
            
        }
    }
}
