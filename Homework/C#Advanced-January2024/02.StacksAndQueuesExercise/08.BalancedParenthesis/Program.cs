namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> openBrackets = new();

            if (input.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    openBrackets.Push(c);
                }
                else if (c == ')' && openBrackets.Peek() == '(')
                {
                    openBrackets.Pop();
                }
                else if (c == ']' && openBrackets.Peek() == '[')
                {
                    openBrackets.Pop();
                }
                else if (c == '}' && openBrackets.Peek() == '{')
                {
                    openBrackets.Pop();
                }
            }

            if (openBrackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
