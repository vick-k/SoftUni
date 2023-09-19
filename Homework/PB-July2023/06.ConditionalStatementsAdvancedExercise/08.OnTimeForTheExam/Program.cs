using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arivalHour = int.Parse(Console.ReadLine());
            int arivalMin = int.Parse(Console.ReadLine());

            // Total time in minutes
            int examTimeInMin = examHour * 60 + examMin;
            int arivalTimeInMin = arivalHour * 60 + arivalMin;

            // Determine the status of arrival (Late, On time, Early)
            if (arivalTimeInMin > examTimeInMin)
            {
                Console.WriteLine("Late");
            }
            else if (examTimeInMin - arivalTimeInMin == 0 || examTimeInMin - arivalTimeInMin <= 30)
            {
                Console.WriteLine("On time");
            }
            else if (examTimeInMin - arivalTimeInMin > 30)
            {
                Console.WriteLine("Early");
            }

            // Print second line
            int timeDiff = Math.Abs(arivalTimeInMin - examTimeInMin);
            int hour = timeDiff / 60;
            int min = timeDiff % 60;

            if (arivalTimeInMin > examTimeInMin)
            {
                if (timeDiff < 60)
                {
                    Console.WriteLine($"{timeDiff} minutes after the start");
                }
                else
                {
                    if (min > 9)
                    {
                        Console.WriteLine($"{hour}:{min} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hour}:0{min} hours after the start");
                    }
                }
            }
            else if (arivalTimeInMin < examTimeInMin)
            {
                if (timeDiff < 60)
                {
                    Console.WriteLine($"{timeDiff} minutes before the start");
                }
                else
                {
                    if (min > 9)
                    {
                        Console.WriteLine($"{hour}:{min} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hour}:0{min} hours before the start");
                    }
                }
            }
        }
    }
}
