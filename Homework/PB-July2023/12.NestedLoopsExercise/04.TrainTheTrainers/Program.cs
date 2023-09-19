using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int judgesCount = int.Parse(Console.ReadLine());
            double gradeSum = 0;
            double gradeTotal = 0;
            int gradesCount = 0;

            string presentationName = Console.ReadLine();
            while (presentationName != "Finish")
            {
                for (int i = 0; i < judgesCount; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                    gradeTotal += grade;
                    gradesCount++;
                }

                Console.WriteLine($"{presentationName} - {gradeSum / judgesCount:f2}.");
                gradeSum = 0;
                presentationName = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {gradeTotal / gradesCount:f2}.");
        }
    }
}
