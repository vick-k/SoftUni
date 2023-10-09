namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double secondNumber = int.Parse(Console.ReadLine());

            Calculate(firstNumber, operation, secondNumber);
        }

        static void Calculate(double firstNumber, char operation, double secondNumber)
        {
            double result = 0;

            if (operation == '+')
            {
                result = firstNumber + secondNumber;
            }
            else if (operation == '-')
            {
                result = firstNumber - secondNumber;
            }
            else if (operation == '*')
            {
                result = firstNumber * secondNumber;
            }
            else if (operation == '/')
            {
                result = firstNumber / secondNumber;
            }

            Console.WriteLine(result);
        }
    }
}