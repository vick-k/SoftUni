namespace _03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Shoot")
                {
                    int index = int.Parse(command[1]);
                    int power = int.Parse(command[2]);

                    if (index < 0 || index > targets.Count - 1)
                    {
                        continue;
                    }

                    targets[index] -= power;

                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (command[0] == "Add")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);

                    if (index < 0 || index > targets.Count - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else
                    {
                        targets.Insert(index, value);
                    }
                }
                else if (command[0] == "Strike")
                {
                    int index = int.Parse(command[1]);
                    int radius = int.Parse(command[2]);

                    if (index < 0 || index > targets.Count - 1 || index - radius < 0 || index + radius > targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        int destroyedIndices = radius * 2 + 1;
                        int rightIndex = index + radius;

                        for (int i = 0; i < destroyedIndices; i++)
                        {
                            targets.RemoveAt(rightIndex - i);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}