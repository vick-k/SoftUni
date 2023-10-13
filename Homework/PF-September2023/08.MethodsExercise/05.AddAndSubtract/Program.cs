namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = Sum(firstNumber, secondNumber);
            int subtract = Subtract(thirdNumber, sum);

            Console.WriteLine(Subtract(thirdNumber, sum));
        }

        static int Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static int Subtract(int thirdNumber, int sum)
        {
            return sum - thirdNumber;
        }

    }
}