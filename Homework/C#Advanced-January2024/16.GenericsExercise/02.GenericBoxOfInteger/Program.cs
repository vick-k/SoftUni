namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stringsCount; i++)
            {
                int input = int.Parse(Console.ReadLine());

                Box<int> box = new(input);

                Console.WriteLine(box);
            }
        }
    }
}
