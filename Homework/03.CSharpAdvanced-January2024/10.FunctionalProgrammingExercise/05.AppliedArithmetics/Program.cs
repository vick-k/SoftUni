namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(n => n + 1).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(n => n * 2).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(n => n - 1).ToList();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }
            }
        }
    }
}
