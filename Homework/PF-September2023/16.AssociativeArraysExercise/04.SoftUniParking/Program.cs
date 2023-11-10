namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> usersMap = new Dictionary<string, string>();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split();

                string action = command[0];
                string username = command[1];

                if (action == "register")
                {
                    string licensePlateNumber = command[2];

                    if (!usersMap.ContainsKey(username))
                    {
                        usersMap.Add(username, licensePlateNumber);

                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else // action == unregister
                {
                    if (usersMap.ContainsKey(username))
                    {
                        usersMap.Remove(username);

                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var kvp in usersMap)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}