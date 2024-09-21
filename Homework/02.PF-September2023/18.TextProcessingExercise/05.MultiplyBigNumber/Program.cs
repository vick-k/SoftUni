using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            int memoryDigit = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(number[i].ToString());
                int currentResult = currentDigit * multiplier + memoryDigit;

                result.Append(currentResult % 10);
                memoryDigit = currentResult / 10;
            }

            if (memoryDigit > 0)
            {
                result.Append(memoryDigit);
            }

            string finalResult = new string(result.ToString().Reverse().ToArray());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(finalResult);
            }
        }
    }
}