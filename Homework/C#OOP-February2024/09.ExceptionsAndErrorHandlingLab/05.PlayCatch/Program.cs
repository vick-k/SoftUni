namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                string[] arguments = Console.ReadLine().Split();
                string command = arguments[0];

                try
                {
                    if (command == "Replace")
                    {
                        int index = int.Parse(arguments[1]);
                        int element = int.Parse(arguments[2]);
                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(arguments[1]);
                        int endIndex = int.Parse(arguments[2]);

                        Console.WriteLine(string.Join(", ", numbers.GetRange(startIndex, endIndex - startIndex + 1)));
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(arguments[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is FormatException)
                    {
                        exceptionsCount++;
                        Console.WriteLine("The variable is not in the correct format!");
                    }
                    else if (ex is ArgumentOutOfRangeException or ArgumentException)
                    {
                        exceptionsCount++;
                        Console.WriteLine("The index does not exist!");
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
