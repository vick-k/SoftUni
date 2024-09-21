namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new();
            personOne.Name = "Peter";
            personOne.Age = 20;

            Person personTwo = new("George", 18);

            Person personThree = new() { Name = "Jose", Age = 43 };
        }
    }
}
