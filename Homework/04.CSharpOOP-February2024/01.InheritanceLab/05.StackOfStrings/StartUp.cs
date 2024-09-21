namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new();

            Console.WriteLine(strings.IsEmpty());

            strings.Push("1");
            strings.Push("2");
            strings.Push("3");

            Console.WriteLine(strings.IsEmpty());

            string[] arr = new string[] { "4", "5", "6" };

            strings.AddRange(arr);
        }
    }
}
