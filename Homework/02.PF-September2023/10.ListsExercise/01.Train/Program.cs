namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> initialWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    int passengers = int.Parse(command[1]);

                    initialWagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(command[0]);

                    for (int i = 0; i < initialWagons.Count; i++)
                    {
                        if (initialWagons[i] + passengers <= wagonCapacity)
                        {
                            initialWagons[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", initialWagons));
        }
    }
}