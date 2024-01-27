namespace _09._PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestsList = Console.ReadLine().Split().ToList();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commands = input.Split();
                string command = commands[0];
                string secondCommand = commands[1];
                string argument = commands[2];

                Func<string, bool> predicate = GetPredicate(secondCommand, argument);

                if (command == "Remove")
                {
                    guestsList = Remove(guestsList, predicate);
                }
                else if (command == "Double")
                {
                    guestsList = Double(guestsList, predicate);
                }
            }

            if (guestsList.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }

            Console.WriteLine($"{string.Join(", ", guestsList)} are going to the party!");
        }

        private static Func<string, bool> GetPredicate(string command, string substring)
        {
            if (command == "StartsWith")
            {
                return s => s.StartsWith(substring);
            }

            if (command == "EndsWith")
            {
                return s => s.EndsWith(substring);
            }

            if (command == "Length")
            {
                return s => s.Length == int.Parse(substring);
            }

            return default;
        }

        static List<string> Double(List<string> guestsList, Func<string, bool> predicate)
        {
            List<string> result = new List<string>();

            foreach (string guest in guestsList)
            {
                if (predicate(guest))
                {
                    result.Add(guest);
                }

                result.Add(guest);
            }

            return result;
        }

        static List<string> Remove(List<string> guestList, Func<string, bool> predicate)
        {
            guestList = guestList.Where(guest => predicate(guest) == false).ToList();
            return guestList;
        }
    }
}