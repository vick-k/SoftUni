namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new();
            Person personTwo = new(18);
            Person personThree = new("Peter", 20);
        }
    }
}
