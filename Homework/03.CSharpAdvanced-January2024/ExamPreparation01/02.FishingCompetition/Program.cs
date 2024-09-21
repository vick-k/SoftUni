namespace _02.FishingCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int[] boatPosition = new int[2];

            for (int i = 0; i < matrixSize; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = row[j];

                    if (row[j] == 'S')
                    {
                        boatPosition[0] = i;
                        boatPosition[1] = j;
                    }
                }
            }

            int fishQuantity = 0;
            int fishQuota = 20;
            bool quotaReached = false;

            string command;
            while ((command = Console.ReadLine()) != "collect the nets")
            {
                matrix[boatPosition[0], boatPosition[1]] = '-';

                if (command == "up")
                {
                    if (boatPosition[0] - 1 < 0)
                    {
                        boatPosition[0] = matrixSize - 1;
                    }
                    else
                    {
                        boatPosition[0] = boatPosition[0] - 1;
                    }
                }
                else if (command == "down")
                {
                    if (boatPosition[0] + 1 >= matrixSize)
                    {
                        boatPosition[0] = 0;
                    }
                    else
                    {
                        boatPosition[0] = boatPosition[0] + 1;
                    }
                }
                else if (command == "left")
                {
                    if (boatPosition[1] - 1 < 0)
                    {
                        boatPosition[1] = matrixSize - 1;
                    }
                    else
                    {
                        boatPosition[1] = boatPosition[1] - 1;
                    }
                }
                else if (command == "right")
                {
                    if (boatPosition[1] + 1 >= matrixSize)
                    {
                        boatPosition[1] = 0;
                    }
                    else
                    {
                        boatPosition[1] = boatPosition[1] + 1;
                    }
                }

                if (matrix[boatPosition[0], boatPosition[1]] == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{boatPosition[0]},{boatPosition[1]}]");
                    return;
                }
                else if (matrix[boatPosition[0], boatPosition[1]] == '-')
                {
                    matrix[boatPosition[0], boatPosition[1]] = 'S';
                    continue;
                }
                else // land on a fish passage
                {
                    fishQuantity += (int)char.GetNumericValue(matrix[boatPosition[0], boatPosition[1]]);
                    matrix[boatPosition[0], boatPosition[1]] = 'S';

                    if (fishQuantity >= fishQuota && !quotaReached)
                    {
                        quotaReached = true;
                        Console.WriteLine("Success! You managed to reach the quota!");
                    }
                }
            }

            if (fishQuantity < 20)
            {
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {fishQuota - fishQuantity} tons of fish more.");
            }

            if (fishQuantity > 0)
            {
                Console.WriteLine($"Amount of fish caught: {fishQuantity} tons.");
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
