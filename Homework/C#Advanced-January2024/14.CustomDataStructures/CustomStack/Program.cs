namespace CustomStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack customStack = new CustomStack();

            customStack.Push(11);
            customStack.Push(22);
            customStack.Push(33);
            customStack.Push(44);
            customStack.Push(55);
            customStack.Push(66);
            customStack.Push(77);
            customStack.Push(88);
            customStack.Push(99);

            customStack.Pop();
            customStack.Pop();
            customStack.Pop();
            customStack.Pop();
            customStack.Pop();
            customStack.Pop();

            customStack.Peek();

            customStack.ForEach(i => Console.WriteLine(i));
        }
    }
}
