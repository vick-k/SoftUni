namespace _02.TheLift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int wagonCapacity = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] < wagonCapacity)
                {
                    people -= wagonCapacity - lift[i];

                    lift[i] += wagonCapacity - lift[i];

                    if (people < 0)
                    {
                        lift[i] -= Math.Abs(people);

                        Console.WriteLine("The lift has empty spots!");

                        break;
                    }
                }
            }

            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }

            Console.WriteLine(string.Join(" ", lift));
        }
    }
}