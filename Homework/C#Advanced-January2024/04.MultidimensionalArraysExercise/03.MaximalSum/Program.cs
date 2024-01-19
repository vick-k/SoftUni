namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int maximalSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = 0;

                    for (int sqRow = row; sqRow < row + 3; sqRow++)
                    {
                        for (int sqCol = col; sqCol < col + 3; sqCol++)
                        {
                            currentSum += matrix[sqRow, sqCol];
                        }
                    }

                    if (currentSum > maximalSum)
                    {
                        maximalSum = currentSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maximalSum}");

            for (int row = bestRow; row < bestRow + 3; row++)
            {
                for (int col = bestCol; col < bestCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
