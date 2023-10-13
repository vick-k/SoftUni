namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isChanged = false;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);
                    numbers.Add(number);

                    isChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    int number = int.Parse(command[1]);
                    numbers.Remove(number);

                    isChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);
                    numbers.RemoveAt(index);

                    isChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, number);

                    isChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    int number = int.Parse(command[1]);

                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    List<int> evenNumbers = new List<int>();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 0)
                        {
                            evenNumbers.Add(numbers[i]);
                        }
                    }

                    Console.WriteLine(string.Join(" ", evenNumbers));
                }
                else if (command[0] == "PrintOdd")
                {
                    List<int> oddNumbers = new List<int>();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] % 2 == 1)
                        {
                            oddNumbers.Add(numbers[i]);
                        }
                    }

                    Console.WriteLine(string.Join(" ", oddNumbers));
                }
                else if (command[0] == "GetSum")
                {
                    int sum = 0;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        sum += numbers[i];
                    }

                    Console.WriteLine(sum);
                }
                else if (command[0] == "Filter")
                {
                    string condition = command[1];
                    int number = int.Parse(command[2]);

                    if (condition == "<")
                    {
                        List<int> numbersList = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < number)
                            {
                                numbersList.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", numbersList));
                    }
                    else if (condition == ">")
                    {
                        List<int> numbersList = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > number)
                            {
                                numbersList.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", numbersList));
                    }
                    else if (condition == ">=")
                    {
                        List<int> numbersList = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= number)
                            {
                                numbersList.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", numbersList));
                    }
                    else if (condition == "<=")
                    {
                        List<int> numbersList = new List<int>();

                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= number)
                            {
                                numbersList.Add(numbers[i]);
                            }
                        }

                        Console.WriteLine(string.Join(" ", numbersList));
                    }
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}