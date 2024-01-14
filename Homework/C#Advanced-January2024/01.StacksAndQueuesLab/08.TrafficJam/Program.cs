namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCounter = int.Parse(Console.ReadLine());

            Queue<string> queue = new();
            int passedCars = 0;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsCounter; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
