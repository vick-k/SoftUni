namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine()
                .Split()
                .Reverse()
                .ToArray();

            Stack<string> stack = new Stack<string>(expression);

            int firstNumber = int.Parse(stack.Pop());
            int result = firstNumber;

            while (stack.Count > 0)
            {
                char operation = char.Parse(stack.Pop());
                int nextNumber = int.Parse(stack.Pop());

                if (operation == '+')
                {
                    result += nextNumber;
                }
                else if (operation == '-')
                {
                    result -= nextNumber;
                }
            }

            Console.WriteLine(result);
        }
    }
}
