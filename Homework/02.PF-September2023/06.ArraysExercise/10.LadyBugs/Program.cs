namespace _10.LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine()); // size of the field
            int[] initialIndexes = Console.ReadLine() // indexes (positions) of all ladybugs in the beginning
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize];

            foreach (int index in initialIndexes) // set initial field (where the ladybugs are)
            {
                if (index >= 0 && index < fieldSize)
                {
                    field[index] = 1;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] movementCommand = input.Split(); // [ ladybugIndex, direction, flyLength ]

                int ladybugIndex = int.Parse(movementCommand[0]);
                string direction = movementCommand[1];
                int flyLength = int.Parse(movementCommand[2]);

                if (ladybugIndex < 0 || ladybugIndex >= fieldSize || field[ladybugIndex] == 0) // check if the ladybug you want to move is outside of the field or there is such on that index
                {
                    continue;
                }

                field[ladybugIndex] = 0; // the index from which the ladybug flies off becomes 0

                int newPosition = ladybugIndex;

                if (direction == "right")
                {
                    newPosition += flyLength;

                    while (newPosition >= 0 && newPosition < fieldSize) // check if the new position is inside the field
                    {
                        if (field[newPosition] == 0)
                        {
                            field[newPosition] = 1;
                            break;
                        }
                        else
                        {
                            newPosition += flyLength;
                        }
                    }
                }
                else if (direction == "left")
                {
                    newPosition -= flyLength;

                    while (newPosition >= 0 && newPosition < fieldSize) // check if the new position is inside the field
                    {
                        if (field[newPosition] == 0)
                        {
                            field[newPosition] = 1;
                            break;
                        }
                        else
                        {
                            newPosition -= flyLength;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}