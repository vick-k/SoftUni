namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> isValid = name => name.Length <= length;

            names = names
                .Where(name => isValid(name))
                .ToArray();

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
