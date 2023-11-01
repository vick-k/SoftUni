namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Student> studentsList = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                float grade = float.Parse(studentInfo[2]);

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Grade = grade;

                studentsList.Add(student);
            }

            studentsList = studentsList.OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in studentsList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public float Grade { get; set; }
        }
    }
}