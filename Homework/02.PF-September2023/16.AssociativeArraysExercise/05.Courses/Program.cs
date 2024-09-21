namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesMap = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input
                    .Split(" : ");

                string courseName = command[0];
                string studentName = command[1];

                if (!coursesMap.ContainsKey(courseName))
                {
                    List<string> students = new List<string>();

                    students.Add(studentName);

                    coursesMap.Add(courseName, students);
                }
                else
                {
                    coursesMap[courseName].Add(studentName);
                }
            }

            foreach (var kvp in coursesMap)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var student in kvp.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}