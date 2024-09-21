namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> openingBracketsIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBracketsIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int currentClosingBracket = i;
                    int lastOpeningBracket = openingBracketsIndexes.Pop();

                    string subExpression = expression.Substring(lastOpeningBracket, currentClosingBracket - lastOpeningBracket + 1);

                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
