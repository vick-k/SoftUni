namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());

            int[] passengers = new int[wagonsCount];
            int totalPeople = 0;

            for (int i = 0; i < wagonsCount; i++)
            {
                int people = int.Parse(Console.ReadLine());
                totalPeople += people;
                passengers[i] = people;
            }

            Console.Write(string.Join(" ", passengers));
            Console.WriteLine();
            Console.WriteLine(totalPeople);
        }
    }
}