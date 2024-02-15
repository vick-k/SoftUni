namespace _02.TheGambler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[,] board = new char[boardSize, boardSize];
            int currentRow = 0;
            int currentCol = 0;
            int playerCash = 100;

            for (int row = 0; row < boardSize; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < boardSize; col++)
                {
                    board[row, col] = values[col];

                    if (values[col] == 'G')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            bool jackpotWon = false;
            bool outOfBoundaries = false;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (currentRow < 0 || currentRow >= boardSize || currentCol < 0 || currentCol >= boardSize)
                {
                    outOfBoundaries = true;
                    playerCash = 0;
                    break;
                }

                board[currentRow, currentCol] = '-';

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

                if (board[currentRow, currentCol] == '-')
                {
                    board[currentRow, currentCol] = 'G';
                    continue;
                }
                else if (board[currentRow, currentCol] == 'W')
                {
                    playerCash += 100;
                    board[currentRow, currentCol] = 'G';
                }
                else if (board[currentRow, currentCol] == 'P')
                {
                    playerCash -= 200;
                    board[currentRow, currentCol] = 'G';

                    if (playerCash <= 0)
                    {
                        break;
                    }
                }
                else if (board[currentRow, currentCol] == 'J')
                {
                    playerCash += 100000;
                    board[currentRow, currentCol] = 'G';
                    jackpotWon = true;
                    break;
                }
            }

            if (jackpotWon)
            {
                Console.WriteLine("You win the Jackpot!");
                Console.WriteLine($"End of the game. Total amount: {playerCash}$");
            }
            else if (!jackpotWon && playerCash > 0)
            {
                Console.WriteLine($"End of the game. Total amount: {playerCash}$");
            }
            else if (outOfBoundaries || playerCash <= 0)
            {
                Console.WriteLine("Game over! You lost everything!");
            }

            if (playerCash > 0)
            {
                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        Console.Write(board[row, col]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
