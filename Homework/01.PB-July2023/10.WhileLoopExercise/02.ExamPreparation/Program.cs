using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int badGrades = int.Parse(Console.ReadLine());

            string lastProblem = "";
            int badGradesCount = 0;
            int gradesSum = 0;
            int gradesTotal = 0;

            string problemName = Console.ReadLine();
            int grade = int.Parse(Console.ReadLine());
            while (problemName != "Enough")
            {
                if (grade <= 4)
                {
                    badGradesCount++;
                }
                if (badGradesCount >= badGrades)
                {
                    Console.WriteLine($"You need a break, {badGradesCount} poor grades.");
                    break;
                }

                gradesSum += grade;
                gradesTotal++;

                problemName = Console.ReadLine();
                if (problemName != "Enough")
                {
                    lastProblem = problemName;
                    grade = int.Parse(Console.ReadLine());
                }
            }

            // Print output
            if (badGradesCount < badGrades)
            {
                Console.WriteLine($"Average score: {1.0 * gradesSum / gradesTotal:f2}");
                Console.WriteLine($"Number of problems: {gradesTotal}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
