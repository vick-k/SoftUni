using System.Xml.Linq;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsMap = new Dictionary<string, List<double>>();

            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsCount; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsMap.ContainsKey(studentName))
                {
                    List<double> grades = new List<double>();
                    grades.Add(grade);

                    studentsMap.Add(studentName, grades);
                }
                else
                {
                    studentsMap[studentName].Add(grade);
                }
            }

            foreach (var kvp in studentsMap.Where(student => student.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}