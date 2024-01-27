namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int threshold = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int, bool> isValidName = (name, limit) => name.ToCharArray().Select(c => (int)c).Sum() >= limit;

            Func<List<string>, Func<string, int, bool>, string> findName = (names, isValidName) => names.Find(name => isValidName(name, threshold));

            string result = findName(names, isValidName);

            Console.WriteLine(result);
        }
    }
}
