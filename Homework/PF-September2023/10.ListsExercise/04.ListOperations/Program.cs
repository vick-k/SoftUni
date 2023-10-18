namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);

                    numbers.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index < 0 || index > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (command[1] == "left")
                {
                    int count = int.Parse(command[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int firstNumber = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(firstNumber);
                    }
                }
                else if (command[1] == "right")
                {
                    int count = int.Parse(command[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int lastNumber = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, lastNumber);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}