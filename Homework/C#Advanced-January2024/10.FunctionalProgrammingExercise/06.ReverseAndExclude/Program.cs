namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isDividable = num => num % divider != 0;

            numbers = numbers
                .Reverse()
                .Where(num => isDividable(num))
                .ToArray();

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
