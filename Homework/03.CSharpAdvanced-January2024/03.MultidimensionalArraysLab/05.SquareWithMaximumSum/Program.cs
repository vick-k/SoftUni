namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] values = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int biggestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int squareSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (squareSum > biggestSum)
                    {
                        biggestSum = squareSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRow, bestCol]} {matrix[bestRow, bestCol + 1]}");
            Console.WriteLine($"{matrix[bestRow + 1, bestCol]} {matrix[bestRow + 1, bestCol + 1]}");
            Console.WriteLine(biggestSum);


            // ------------------------
            // Solution with NxN matrix
            // ------------------------

            /*
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[] submatrixSize = Console.ReadLine() // Read the size of the submatrix
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int submatrixRows = submatrixSize[0]; // Get the number of the rows of the submatrix
            int submatrixCols = submatrixSize[1]; // Get the number of the cols of the submatrix

            if (submatrixRows > rows || submatrixCols > cols) // Check if the submatrix can fit in the initial matrix
            {
                Console.WriteLine("The submatrix cannot fit in the initial matrix.");
                return;
            }

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] values = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int biggestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - (submatrixRows - 1); row++) // Subtracting the submatrix rows to protect from out of bounds exception
            {
                for (int col = 0; col < matrix.GetLength(1) - (submatrixCols - 1); col++) // Subtracting the submatrix cols to protect from out of bounds exception
                {
                    int submatrixSum = 0;

                    for (int submatrixRow = row; submatrixRow < row + submatrixRows; submatrixRow++) // Iterating the rows of the submatrix
                    {
                        for (int submatrixCol = col; submatrixCol < col + submatrixCols; submatrixCol++) // Iterating the cols of the submatrix
                        {
                            submatrixSum += matrix[submatrixRow, submatrixCol];
                        }
                    }

                    if (submatrixSum > biggestSum)
                    {
                        biggestSum = submatrixSum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            for (int row = 0; row < submatrixRows; row++) // Printing the submatrix
            {
                for (int col = 0; col < submatrixCols; col++)
                {
                    Console.Write($"{matrix[bestRow + row, bestCol + col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
            */
        }
    }
}