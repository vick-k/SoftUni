namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Family family = new();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new();
                person.Name = name;
                person.Age = age;

                family.AddMember(person);
            }

            Console.WriteLine($"{family.GetOldestMember().Name} {family.GetOldestMember().Age}");
        }
    }
}
