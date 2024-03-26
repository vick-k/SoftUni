namespace Serializer
{
    public class StartUp
    {
        static void Main()
        {
            Cat parrentCat1 = new Cat() { Breed = "British Shorthair", Name = "Fluffy", Age = 9, };
            Cat parrentCat2 = new Cat() { Breed = "Unknown", Name = "Spotty", Age = 7, };
            Cat cat = new() { Breed = "British Shorthair", Name = "Toby", Age = 3, Parrents = new() { parrentCat1, parrentCat2 } };

            Dictionary<string, int> courses = new()
            {
                { "C# Advanced", 1 },
                { "C# OOP", 0 }
            };

            double[] scores = { 5.55, 5.44, 6.00, 5.89 };

            Student student = new() { Id = "gosho99", FirstName = "Georgi", LastName = "Georgiev", IsGraduated = false, Cat = cat, Courses = courses, Scores = scores };

            JSONSerializer serializer = new();
            string json = serializer.ToJSON(student);
            Console.WriteLine(json);
        }
    }
}
