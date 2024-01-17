namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new(orders);

            Console.WriteLine(queue.Max());

            for (int i = 0; i < orders.Length; i++)
            {
                int currentOrder = queue.Peek();

                if (currentOrder > foodQuantity)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }

                foodQuantity -= currentOrder;
                queue.Dequeue();
            }

            Console.WriteLine("Orders complete");
        }
    }
}
