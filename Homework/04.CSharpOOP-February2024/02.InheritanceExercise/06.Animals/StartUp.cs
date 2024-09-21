using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new();

            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string animalType = command;
                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (age < 0 || (gender != "Male" && gender != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animalType == "Cat")
                {
                    Cat cat = new(name, age, gender);
                    animals.Add(cat);
                }
                else if (animalType == "Dog")
                {
                    Dog dog = new(name, age, gender);
                    animals.Add(dog);
                }
                else if (animalType == "Frog")
                {
                    Frog frog = new(name, age, gender);
                    animals.Add(frog);
                }
                else if (animalType == "Kitten")
                {
                    Kitten kitten = new(name, age);
                    animals.Add(kitten);
                }
                else if (animalType == "Tomcat")
                {
                    Tomcat tomcat = new(name, age);
                    animals.Add(tomcat);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.GetType().Name}");
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
