namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = values[col];
                }
            }

            int removedKnights = 0;

            for (int threatLevel = 8; threatLevel > 0; threatLevel--)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        int knightThreat = 0;

                        if (board[row, col] == 'K')
                        {
                            List<int> validMoves = ValidMoves(board, row, col);

                            for (int i = 0; i < validMoves.Count; i++)
                            {
                                knightThreat = CalculateKnightThreat(board, row, col, knightThreat, validMoves, i);
                            }

                            if (knightThreat == threatLevel)
                            {
                                board[row, col] = '0';
                                removedKnights++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(removedKnights);
        }

        static int CalculateKnightThreat(char[,] board, int row, int col, int knightThreat, List<int> validMoves, int i)
        {
            if (validMoves[i] == 1 && board[row - 2, col + 1] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 2 && board[row - 1, col + 2] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 3 && board[row + 1, col + 2] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 4 && board[row + 2, col + 1] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 5 && board[row + 2, col - 1] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 6 && board[row + 1, col - 2] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 7 && board[row - 1, col - 2] == 'K')
            {
                knightThreat++;
            }
            else if (validMoves[i] == 8 && board[row - 2, col - 1] == 'K')
            {
                knightThreat++;
            }

            return knightThreat;
        }

        static List<int> ValidMoves(char[,] board, int row, int col)
        {
            List<int> validMoves = new List<int>();

            if (row - 2 >= 0 && col + 1 < board.GetLength(1))
            {
                validMoves.Add(1);
            }

            if (row - 1 >= 0 && col + 2 < board.GetLength(1))
            {
                validMoves.Add(2);
            }

            if (row + 1 < board.GetLength(0) && col + 2 < board.GetLength(1))
            {
                validMoves.Add(3);
            }

            if (row + 2 < board.GetLength(0) && col + 1 < board.GetLength(1))
            {
                validMoves.Add(4);
            }

            if (row + 2 < board.GetLength(0) && col - 1 >= 0)
            {
                validMoves.Add(5);
            }

            if (row + 1 < board.GetLength(0) && col - 2 >= 0)
            {
                validMoves.Add(6);
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                validMoves.Add(7);
            }

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                validMoves.Add(8);
            }

            return validMoves;
        }
    }
}
