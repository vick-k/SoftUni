namespace _03.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                OperationAdd(firstNumber, secondNumber);
            }
            else if (operation == "subtract")
            {
                OperationSubtract(firstNumber, secondNumber);
            }
            else if (operation == "multiply")
            {
                OperationMultiply(firstNumber, secondNumber);
            }
            else if (operation == "divide")
            {
                OperationDivide(firstNumber, secondNumber);
            }
        }

        static void OperationAdd(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }

        static void OperationSubtract(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void OperationMultiply(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void OperationDivide(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }
    }
}