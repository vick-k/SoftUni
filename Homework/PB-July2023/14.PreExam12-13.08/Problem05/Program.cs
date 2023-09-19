using System;

namespace Problem05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int dailyGoal = int.Parse(Console.ReadLine());

            // Read the rest of the input and calculate the earned money
            int earnedMoney = 0;
            bool dailyGoalReached = false;

            string input = Console.ReadLine();
            while (input != "closed")
            {
                if (input == "haircut")
                {
                    string haircutType = Console.ReadLine();
                    if (haircutType == "mens")
                    {
                        earnedMoney += 15;
                    }
                    else if (haircutType == "ladies")
                    {
                        earnedMoney += 20;
                    }
                    else if (haircutType == "kids")
                    {
                        earnedMoney += 10;
                    }
                }
                else if (input == "color")
                {
                    string colorType = Console.ReadLine();
                    if (colorType == "touch up")
                    {
                        earnedMoney += 20;
                    }
                    else if (colorType == "full color")
                    {
                        earnedMoney += 30;
                    }
                }

                if (earnedMoney >= dailyGoal)
                {
                    dailyGoalReached = true;
                    break;
                }

                input = Console.ReadLine();
            }

            // Print output
            if (dailyGoalReached)
            {
                Console.WriteLine("You have reached your target for the day!");
            }
            else
            {
                Console.WriteLine($"Target not reached! You need {dailyGoal - earnedMoney}lv. more.");
            }

            Console.WriteLine($"Earned money: {earnedMoney}lv.");
        }
    }
}
