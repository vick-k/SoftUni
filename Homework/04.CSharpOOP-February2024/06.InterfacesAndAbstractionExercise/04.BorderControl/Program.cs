namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIndividual> individuals = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();

                if (arguments.Length == 3)
                {
                    string name = arguments[0];
                    int age = int.Parse(arguments[1]);
                    string id = arguments[2];

                    IIndividual citizen = new Citizen(name, age, id);
                    individuals.Add(citizen);
                }
                else if (arguments.Length == 2)
                {
                    string model = arguments[0];
                    string id = arguments[1];

                    IIndividual robot = new Robot(model, id);
                    individuals.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (IIndividual individual in individuals)
            {
                if (individual.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(individual.Id);
                }
            }
        }
    }
}
