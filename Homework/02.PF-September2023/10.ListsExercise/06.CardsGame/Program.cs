namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> playerTwoHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < playerOneHand.Count; i++)
            {
                if (playerOneHand[i] == playerTwoHand[i])
                {
                    playerOneHand.RemoveAt(i);
                    playerTwoHand.RemoveAt(i);
                }
                else if (playerOneHand[i] > playerTwoHand[i])
                {
                    playerOneHand.Add(playerOneHand[i]);
                    playerOneHand.Add(playerTwoHand[i]);

                    playerOneHand.RemoveAt(i);
                    playerTwoHand.RemoveAt(i);
                }
                else // playerTwoHand > playerOneHand
                {
                    playerTwoHand.Add(playerTwoHand[i]);
                    playerTwoHand.Add(playerOneHand[i]);

                    playerOneHand.RemoveAt(i);
                    playerTwoHand.RemoveAt(i);
                }

                if (playerOneHand.Count == 0 || playerTwoHand.Count == 0)
                {
                    break;
                }

                i--;
            }

            if (playerOneHand.Count > playerTwoHand.Count)
            {
                Console.WriteLine($"First player wins! Sum: {playerOneHand.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwoHand.Sum()}");
            }
        }
    }
}