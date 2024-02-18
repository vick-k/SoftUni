namespace _02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] airspace = new char[size, size];

            int currentRow = 0;
            int currentCol = 0;
            int enemiesCount = 0;
            int armor = 300;

            for (int row = 0; row < size; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    airspace[row, col] = values[col];

                    if (values[col] == 'J')
                    {
                        currentRow = row;
                        currentCol = col;
                    }

                    if (values[col] == 'E')
                    {
                        enemiesCount++;
                    }
                }
            }

            while (armor > 0 && enemiesCount > 0)
            {
                string command = Console.ReadLine();

                airspace[currentRow, currentCol] = '-';

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

                if (airspace[currentRow, currentCol] == 'E')
                {
                    enemiesCount--;

                    if (enemiesCount == 0)
                    {
                        airspace[currentRow, currentCol] = 'J';
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        break;
                    }
                    else
                    {
                        armor -= 100;

                        if (armor == 0)
                        {
                            airspace[currentRow, currentCol] = 'J';
                            Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                            break;
                        }
                        else
                        {
                            airspace[currentRow, currentCol] = '-';
                            continue;
                        }
                    }
                }

                if (airspace[currentRow, currentCol] == 'R')
                {
                    armor = 300;
                    airspace[currentRow, currentCol] = '-';
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(airspace[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
