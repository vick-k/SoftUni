namespace Serializer
{
    public class StartUp
    {
        static void Main()
        {
            Student student = new() { Id = "gosho99", FirstName = "Georgi", LastName = "Georgiev", Score = 5.55, IsGraduated = false };
            Cat cat = new() { Breed = "British Shorthair", Name = "Toby", Age = 9 };

            JSONSerializer.ToJSON(student);
            JSONSerializer.ToJSON(cat);

            Student studentFromFile = JSONSerializer.FromJSON<Student>("Student.json");
            Cat catFromFile = JSONSerializer.FromJSON<Cat>("Cat.json");
        }
    }
}
