namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new();

            for (int i = 0; i < elementsCount; i++)
            {
                Box<string> box = new(Console.ReadLine());
                boxes.Add(box);
            }

            string comparator = Console.ReadLine();

            Console.WriteLine(Box<string>.CountGreaterElements(boxes, comparator));
        }
    }
}
