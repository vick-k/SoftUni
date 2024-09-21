namespace _01.RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> programmersTime = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> tasks = new(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int darthVaderCount = 0;
            int thorCount = 0;
            int bigBlueRubberCount = 0;
            int smallYellowRubberCount = 0;


            while (programmersTime.Count > 0 || tasks.Count > 0)
            {
                if (programmersTime.Peek() * tasks.Peek() <= 60)
                {
                    darthVaderCount++;
                    RemoveElement(programmersTime, tasks);
                }
                else if (programmersTime.Peek() * tasks.Peek() <= 120)
                {
                    thorCount++;
                    RemoveElement(programmersTime, tasks);
                }
                else if (programmersTime.Peek() * tasks.Peek() <= 180)
                {
                    bigBlueRubberCount++;
                    RemoveElement(programmersTime, tasks);
                }
                else if (programmersTime.Peek() * tasks.Peek() <= 240)
                {
                    smallYellowRubberCount++;
                    RemoveElement(programmersTime, tasks);
                }
                else
                {
                    tasks.Push(tasks.Pop() - 2);
                    programmersTime.Enqueue(programmersTime.Dequeue());
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {darthVaderCount}");
            Console.WriteLine($"Thor Ducky: {thorCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberCount}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberCount}");
        }

        private static void RemoveElement(Queue<int> programmersTime, Stack<int> tasks)
        {
            programmersTime.Dequeue();
            tasks.Pop();
        }
    }
}
