namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new();

            for (int i = 0; i < elementsCount; i++)
            {
                Box<double> box = new(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double comparator = double.Parse(Console.ReadLine());

            Console.WriteLine(Box<double>.CountGreaterElements(boxes, comparator));
        }
    }
}
