namespace _02.MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[,] matrix = new char[rows, cols];
            int currentRow = 0;
            int currentCol = 0;
            int cheeseCount = 0;
            bool isCaught = false;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }

                    if (input[col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "danger")
            {
                int lastRow = currentRow;
                int lastCol = currentCol;

                if (command == "up")
                {
                    matrix[currentRow, currentCol] = '*';
                    currentRow--;
                }
                else if (command == "down")
                {
                    matrix[currentRow, currentCol] = '*';
                    currentRow++;
                }
                else if (command == "left")
                {
                    matrix[currentRow, currentCol] = '*';
                    currentCol--;
                }
                else if (command == "right")
                {
                    matrix[currentRow, currentCol] = '*';
                    currentCol++;
                }

                if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols)
                {
                    Console.WriteLine("No more cheese for tonight!");
                    matrix[lastRow, lastCol] = 'M';
                    isCaught = true;
                    break;
                }
                else if (matrix[currentRow, currentCol] == 'T')
                {
                    Console.WriteLine("Mouse is trapped!");
                    matrix[currentRow, currentCol] = 'M';
                    isCaught = true;
                    break;
                }
                else if (matrix[currentRow, currentCol] == '@')
                {
                    currentRow = lastRow;
                    currentCol = lastCol;
                    matrix[lastRow, lastCol] = 'M';
                }
                else if (matrix[currentRow, currentCol] == 'C')
                {
                    cheeseCount--;
                    matrix[currentRow, currentCol] = 'M';

                    if (cheeseCount == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        break;
                    }
                }
                else // step on an empty spot (*)
                {
                    matrix[currentRow, currentCol] = 'M';
                }
            }

            if (cheeseCount > 0 && !isCaught)
            {
                Console.WriteLine("Mouse will come back later!");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
