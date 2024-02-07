namespace _01.GenericBoxOfString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stringsCount; i++)
            {
                string input = Console.ReadLine();

                Box<string> box = new(input);

                Console.WriteLine(box);
            }
        }
    }
}
