namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<string> pumps = new();

            for (int i = 0; i < pumpsCount; i++)
            {
                string pumpStats = Console.ReadLine();

                pumps.Enqueue(pumpStats);
            }

            int tankPetrol = 0;
            int pumpIndex = 0;

            for (int i = 0; i < pumps.Count; i++)
            {
                int[] arguments = pumps.Peek()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int petrolAmount = arguments[0];
                int distanceToNextPump = arguments[1];

                tankPetrol += petrolAmount;

                if (tankPetrol - distanceToNextPump < 0)
                {
                    pumpIndex += i + 1;
                    tankPetrol = 0;
                    i = -1;
                    pumps.Enqueue(pumps.Dequeue());
                    continue;
                }

                tankPetrol -= distanceToNextPump;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(pumpIndex);
        }
    }
}
