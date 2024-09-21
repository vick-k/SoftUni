namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personInfo = input
                    .Split();

                string name = personInfo[0];
                string id = personInfo[1];
                int age = int.Parse(personInfo[2]);

                bool duplicatedID = personsList.Exists(p => p.ID == id);

                if (duplicatedID)
                {
                    Person duplicatedPerson = personsList.Find(p => p.ID == id);

                    duplicatedPerson.Name = name;
                    duplicatedPerson.Age = age;
                }
                else
                {
                    Person person = new Person();

                    person.Name = name;
                    person.ID = id;
                    person.Age = age;

                    personsList.Add(person);
                }
            }

            personsList = personsList.OrderBy(p => p.Age).ToList();

            foreach (Person person in personsList)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }
        }
    }
}