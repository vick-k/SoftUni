namespace _01.MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> armorValues = new(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> strikeValues = new(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int killedMonsters = 0;

            while (armorValues.Count > 0 && strikeValues.Count > 0)
            {
                if (strikeValues.Peek() >= armorValues.Peek())
                {
                    killedMonsters++;
                    int remainingImpact = strikeValues.Pop() - armorValues.Dequeue();

                    if (remainingImpact == 0)
                    {
                        continue;
                    }

                    if (strikeValues.Count > 0)
                    {
                        strikeValues.Push(strikeValues.Pop() + remainingImpact);
                    }
                    else
                    {
                        strikeValues.Push(remainingImpact);
                    }
                }
                else
                {
                    int impact = strikeValues.Pop();
                    int remainingArmor = armorValues.Dequeue() - impact;

                    armorValues.Enqueue(remainingArmor);
                }
            }
            
            if (armorValues.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if (strikeValues.Count == 0)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {killedMonsters}");
        }
    }
}
