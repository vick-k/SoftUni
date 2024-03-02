using _05.BirthdayCelebrations;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIndividual> individuals = new();
            List<IBirthable> birthables = new();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();

                if (arguments.Length == 5) // Citizen
                {
                    string name = arguments[1];
                    int age = int.Parse(arguments[2]);
                    string id = arguments[3];
                    string birthdate = arguments[4];

                    IBirthable citizen = new Citizen(name, age, id, birthdate);
                    birthables.Add(citizen);
                }
                else if (arguments.Length == 3 && arguments[0] == "Robot")
                {
                    string model = arguments[1];
                    string id = arguments[2];

                    IIndividual robot = new Robot(model, id);
                    individuals.Add(robot);
                }
                else if (arguments.Length == 3 && arguments[0] == "Pet")
                {
                    string name = arguments[1];
                    string birthdate = arguments[2];

                    IBirthable pet = new Pet(name, birthdate);
                    birthables.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (IBirthable birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
