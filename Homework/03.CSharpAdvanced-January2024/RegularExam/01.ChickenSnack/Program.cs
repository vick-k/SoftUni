namespace _01.ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> money = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> prices = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int foodCount = 0;

            while (money.Count > 0 && prices.Count > 0)
            {
                if (money.Peek() == prices.Peek())
                {
                    foodCount++;
                    money.Pop();
                    prices.Dequeue();
                }
                else if (money.Peek() > prices.Peek())
                {
                    foodCount++;
                    int change = money.Pop() - prices.Dequeue();

                    if (money.Count > 0)
                    {
                        money.Push(money.Pop() + change);
                    }
                    else
                    {
                        money.Push(change);
                    }
                }
                else if (money.Peek() < prices.Peek())
                {
                    money.Pop();
                    prices.Dequeue();
                }
            }

            if (foodCount >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {foodCount} foods.");
            }
            else if (foodCount == 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} food.");
            }
            else if (foodCount > 1)
            {
                Console.WriteLine($"Henry ate: {foodCount} foods.");
            }
            else if (foodCount == 0)
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
