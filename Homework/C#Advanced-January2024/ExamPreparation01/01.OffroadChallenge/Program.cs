namespace _01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuel = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> additionalFuel = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> fuelNeeded = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            
            int currentAltitude = 1;

            while (initialFuel.Count > 0)
            {
                if (initialFuel.Pop() - additionalFuel.Dequeue() < fuelNeeded.Dequeue())
                {
                    Console.WriteLine($"John did not reach: Altitude {currentAltitude}");
                    Console.WriteLine("John failed to reach the top.");

                    if (currentAltitude == 1)
                    {
                        Console.WriteLine("John didn't reach any altitude.");
                        return;
                    }

                    string[] reachedAltitudes = new string[currentAltitude - 1];
                    for (int j = 0; j < reachedAltitudes.Length; j++)
                    {
                        reachedAltitudes[j] = $"Altitude {j + 1}";
                    }

                    Console.WriteLine($"Reached altitudes: {string.Join(", ", reachedAltitudes)}");
                    return;
                }
                else
                {
                    Console.WriteLine($"John has reached: Altitude {currentAltitude}");
                    currentAltitude++;
                }
            }

            if (currentAltitude > 4)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}
