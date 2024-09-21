namespace _02.TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[fieldSize, fieldSize];
            int currentRow = 0;
            int currentCol = 0;
            int hazelnutsCount = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = values[col];

                    if (field[row, col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            bool isScrewedUp = false;

            foreach (string command in commands)
            {
                if (command == "up")
                {
                    currentRow--;
                }
                else if (command == "down")
                {
                    currentRow++;
                }
                else if (command == "left")
                {
                    currentCol--;
                }
                else if (command == "right")
                {
                    currentCol++;
                }

                if (currentRow < 0 || currentRow >= fieldSize || currentCol < 0 || currentCol >= fieldSize)
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    isScrewedUp = true;
                    break;
                }

                if (field[currentRow, currentCol] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    isScrewedUp = true;
                    break;
                }

                if (field[currentRow, currentCol] == 'h')
                {
                    hazelnutsCount++;
                    field[currentRow, currentCol] = '*';

                    if (hazelnutsCount == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        break;
                    }

                    continue;
                }
            }

            if (hazelnutsCount < 3 && !isScrewedUp)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }

            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
        }
    }
}
