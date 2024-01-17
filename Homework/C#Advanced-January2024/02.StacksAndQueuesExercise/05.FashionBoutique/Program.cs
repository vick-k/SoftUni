namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new(clothes);

            int takenClothes = 0;
            int racksCount = 1;

            for (int i = 0; i < clothes.Length; i++)
            {
                int currentClothing = stack.Pop();
                takenClothes += currentClothing;

                if (takenClothes > rackCapacity)
                {
                    racksCount++;
                    takenClothes = currentClothing;
                    continue;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
