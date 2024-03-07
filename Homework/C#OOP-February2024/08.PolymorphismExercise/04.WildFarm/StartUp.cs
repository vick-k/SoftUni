namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArguments = command.Split();
                string type = animalArguments[0];
                string name = animalArguments[1];
                double weight = double.Parse(animalArguments[2]);

                string[] foodArguments = Console.ReadLine().Split();
                string foodType = foodArguments[0];
                int quantity = int.Parse(foodArguments[1]);

                if (type == "Owl")
                {
                    double wingSize = double.Parse(animalArguments[3]);
                    Animal owl = new Owl(name, weight, wingSize);
                    animals.Add(owl);
                    owl.AskForFood();
                    owl.EatFood(foodType, quantity);
                }
                else if (type == "Hen")
                {
                    double wingSize = double.Parse(animalArguments[3]);
                    Animal hen = new Hen(name, weight, wingSize);
                    animals.Add(hen);
                    hen.AskForFood();
                    hen.EatFood(foodType, quantity);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = animalArguments[3];
                    Animal mouse = new Mouse(name, weight, livingRegion);
                    animals.Add(mouse);
                    mouse.AskForFood();
                    mouse.EatFood(foodType, quantity);
                }
                else if (type == "Dog")
                {
                    string livingRegion = animalArguments[3];
                    Animal dog = new Dog(name, weight, livingRegion);
                    animals.Add(dog);
                    dog.AskForFood();
                    dog.EatFood(foodType, quantity);
                }
                else if (type == "Cat")
                {
                    string livingRegion = animalArguments[3];
                    string breed = animalArguments[4];
                    Animal cat = new Cat(name, weight, livingRegion, breed);
                    animals.Add(cat);
                    cat.AskForFood();
                    cat.EatFood(foodType, quantity);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = animalArguments[3];
                    string breed = animalArguments[4];
                    Animal tiger = new Tiger(name, weight, livingRegion, breed);
                    animals.Add(tiger);
                    tiger.AskForFood();
                    tiger.EatFood(foodType, quantity);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
