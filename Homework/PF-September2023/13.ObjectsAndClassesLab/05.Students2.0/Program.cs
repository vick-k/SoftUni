namespace _05.Students2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] studentInfo = input.Split();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string homeTown = studentInfo[3];

                if (studentsList.Exists(s => s.FirstName == firstName && s.LastName == lastName))
                {
                    int index = studentsList.FindIndex(s => s.FirstName == firstName && s.LastName == lastName);

                    studentsList[index].Age = age;
                    studentsList[index].HomeTown = homeTown;
                }
                else
                {
                    Student student = new Student();

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = homeTown;

                    studentsList.Add(student);
                }

                // SECOND VARIANT WITH FOR LOOP (comment from Line 19 to Line 36)
                //bool studentExist = false;

                //for (int i = 0; i < studentsList.Count; i++)
                //{
                //    if (studentsList[i].FirstName == firstName && studentsList[i].LastName == lastName)
                //    {
                //        studentsList[i].Age = age;
                //        studentsList[i].HomeTown = homeTown;

                //        studentExist = true;
                //    }
                //}

                //if (!studentExist)
                //{
                //    Student student = new Student();

                //    student.FirstName = firstName;
                //    student.LastName = lastName;
                //    student.Age = age;
                //    student.HomeTown = homeTown;

                //    studentsList.Add(student);
                //}
            }

            string cityFilter = Console.ReadLine();

            foreach (Student student in studentsList)
            {
                if (cityFilter == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string HomeTown { get; set; }
        }
    }
}