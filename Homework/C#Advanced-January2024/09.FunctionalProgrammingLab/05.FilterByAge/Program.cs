using System;
using System.Threading.Channels;

namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);

            string format = Console.ReadLine();

            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);
        }

        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            people = people.Where(filter).ToList();
            people.ForEach(printer);
        }

        private static Action<Person> CreatePrinter(string format)
        {
            if (format == "name age")
            {
                return person => Console.WriteLine($"{person.Name} - {person.Age}");
            }
            else if (format == "name")
            {
                return person => Console.WriteLine($"{person.Name}");
            }
            else if (format == "age")
            {
                return person => Console.WriteLine($"{person.Age}");
            }
            else
            {
                return null;
            }
        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            if (condition == "younger")
            {
                return person => person.Age < ageThreshold;
            }
            else if (condition == "older")
            {
                return person => person.Age >= ageThreshold;
            }
            else
            {
                return null;
            }
        }

        private static List<Person> ReadPeople()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person person = new Person() { Name = name, Age = age };
                people.Add(person);
            }

            return people;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
