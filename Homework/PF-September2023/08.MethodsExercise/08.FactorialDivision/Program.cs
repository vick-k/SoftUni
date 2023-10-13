namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long firstFactorial = GetFirstFactorial(firstNumber);
            long secondFactorial = GetSecondFactorial(secondNumber);

            PrintResult(firstFactorial, secondFactorial);
        }


        static long GetFirstFactorial(int firstNumber)
        {
            long firstFactorial = 1;

            for (int i = 2; i <= firstNumber; i++)
            {
                firstFactorial *= i;
            }

            return firstFactorial;
        }

        static long GetSecondFactorial(int secondNumber)
        {
            long secondFactorial = 1;

            for (int i = 2; i <= secondNumber; i++)
            {
                secondFactorial *= i;
            }

            return secondFactorial;
        }

        static void PrintResult(long firstFactorial, long secondFactorial)
        {
            double result = 1.0 * firstFactorial / secondFactorial;

            Console.WriteLine($"{result:f2}");
        }
    }
}