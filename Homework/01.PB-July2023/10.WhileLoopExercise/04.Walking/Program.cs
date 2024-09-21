using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Finding the total steps and if the goal is reached or not
            int totalSteps = 0;
            while (totalSteps < 10000)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    int finalSteps = int.Parse(Console.ReadLine());
                    totalSteps += finalSteps;
                    break;
                }

                int walkedSteps = int.Parse(input);
                totalSteps += walkedSteps;
            }
            int deltaSteps = Math.Abs(totalSteps - 10000);

            // Print output
            if (totalSteps >= 10000)
            {
                Console.WriteLine($"Goal reached! Good job!");
                Console.WriteLine($"{deltaSteps} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{deltaSteps} more steps to reach goal.");
            }
        }
    }
}