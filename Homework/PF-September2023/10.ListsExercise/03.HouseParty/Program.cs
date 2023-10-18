using System.Xml.Linq;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            List<string> guestsList = new List<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                List<string> command = Console.ReadLine()
                    .Split()
                    .ToList();

                string name = command[0];

                if (command[2] == "going!")
                {

                    if (guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guestsList.Add(name);
                    }
                }
                else if (command[2] == "not")
                {
                    if (guestsList.Contains(name))
                    {
                        guestsList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join("\n", guestsList));
        }
    }
}