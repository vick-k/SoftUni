namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            CheckGrade(grade);
        }

        static void CheckGrade(double currentGrade)
        {
            if (currentGrade >= 2.00 && currentGrade <= 2.99)
            {
                Console.WriteLine("Fail");
            }
            else if (currentGrade >= 3.00 && currentGrade <= 3.49)
            {
                Console.WriteLine("Poor");
            }
            else if (currentGrade >= 3.50 && currentGrade <= 4.49)
            {
                Console.WriteLine("Good");
            }
            else if (currentGrade >= 4.50 && currentGrade <= 5.49)
            {
                Console.WriteLine("Very good");
            }
            else if (currentGrade >= 5.50 && currentGrade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}