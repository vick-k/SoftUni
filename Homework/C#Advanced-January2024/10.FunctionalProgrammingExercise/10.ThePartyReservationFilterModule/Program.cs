namespace _10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            var filters = new Dictionary<string, Predicate<string>>();
            ReadFilters(Console.ReadLine(), filters);
            PrintResult(names, filters);
        }

        static void ReadFilters(string input, Dictionary<string, Predicate<string>> filters)
        {
            if (input == "Print")
            {
                return;
            }

            string[] tokens = input.Split(";");
            string command = tokens[0];
            string condition = tokens[1];
            string value = tokens[2];
            string dictKey = condition + value;

            Predicate<string> filter = PredicateConstructor(condition, value);
            if (command == "Add filter")
            {
                filters.Add(dictKey, filter);
            }
            else if (command == "Remove filter")
            {
                filters.Remove(dictKey);
            }

            ReadFilters(Console.ReadLine(), filters); // Recursion
        }

        static Predicate<string> PredicateConstructor(string condition, string value)
        {
            if (condition == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            else if (condition == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            else if (condition == "Length")
            {
                return x => x.Length == int.Parse(value);
            }
            else if (condition == "Contains")
            {
                return x => x.Contains(value);
            }
            else
            {
                return x => x == null;
            }
        }

        static void PrintResult(List<string> names, Dictionary<string, Predicate<string>> filters)
        {
            foreach (var filter in filters.Values)
            {
                Func<List<string>, List<string>> applyFilter = x => x.Where(y => !filter(y)).ToList();
                names = applyFilter(names);
            }

            Console.WriteLine(String.Join(" ", names));
        }
    }
}
