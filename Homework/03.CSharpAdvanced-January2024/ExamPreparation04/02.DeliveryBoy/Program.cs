namespace _02.DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            int initialRow = 0;
            int initialCol = 0;
            int currentRow = 0;
            int currentCol = 0;
            int lastRow = 0;
            int lastCol = 0;

            for (int row = 0; row < matrixSize[0]; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'B')
                    {
                        initialRow = row;
                        initialCol = col;
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command;
            bool shouldStop = false;
            while (!shouldStop)
            {
                command = Console.ReadLine();

                lastRow = currentRow;
                lastCol = currentCol;

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

                if (currentRow < 0 || currentRow >= matrixSize[0] || currentCol < 0 || currentCol >= matrixSize[1])
                {
                    matrix[initialRow, initialCol] = ' ';
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    shouldStop = true;
                    continue;
                }

                if (matrix[currentRow, currentCol] == '*')
                {
                    currentRow = lastRow;
                    currentCol = lastCol;
                    continue;
                }

                if (matrix[currentRow, currentCol] == '-' || matrix[currentRow, currentCol] == '.')
                {
                    matrix[currentRow, currentCol] = '.';
                    continue;
                }

                if (matrix[currentRow, currentCol] == 'P')
                {
                    matrix[currentRow, currentCol] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    continue;
                }

                if (matrix[currentRow, currentCol] == 'A')
                {
                    matrix[currentRow, currentCol] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    shouldStop = true;
                    continue;
                }
            }

            for (int row = 0; row < matrixSize[0]; row++)
            {
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
