using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operationsCount = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> textStates = new();

            for (int i = 0; i < operationsCount; i++)
            {
                string[] arguments = Console.ReadLine()
                    .Split();

                string command = arguments[0];

                if (command == "1")
                {
                    string someString = arguments[1];
                    textStates.Push(text.ToString());
                    text.Append(someString);
                }
                else if (command == "2")
                {
                    int count = int.Parse(arguments[1]);
                    textStates.Push(text.ToString());
                    text.Remove(text.Length - count, count);
                }
                else if (command == "3")
                {
                    int index = int.Parse(arguments[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    string previousState = textStates.Pop().ToString();
                    text.Clear().Append(previousState);
                }
            }
        }
    }
}
