namespace _06.ListManipulationBasics
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
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);

                    numbers.Add(number);
                }
                else if (command[0] == "Remove")
                {
                    int number = int.Parse(command[1]);

                    numbers.Remove(number);
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);

                    numbers.RemoveAt(index);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    numbers.Insert(index, number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}