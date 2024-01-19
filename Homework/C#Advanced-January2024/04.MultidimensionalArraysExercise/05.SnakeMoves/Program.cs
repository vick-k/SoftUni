namespace _05.SnakeMoves
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
            string[,] matrix = new string[rows, cols];

            string snakeString = Console.ReadLine();
            Queue<char> snakeQueue = new(snakeString);

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakeQueue.Peek().ToString();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeQueue.Peek().ToString();
                        snakeQueue.Enqueue(snakeQueue.Dequeue());
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0 ; col < cols ; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
