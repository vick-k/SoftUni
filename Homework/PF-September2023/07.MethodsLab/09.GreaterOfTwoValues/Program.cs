namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();
            string firstValue = Console.ReadLine();
            string secondValue = Console.ReadLine();

            if (valueType == "int")
            {
                GetMax(int.Parse(firstValue), int.Parse(secondValue), valueType);
            }
            else if (valueType == "char")
            {
                GetMax(char.Parse(firstValue), char.Parse(secondValue), valueType);
            }
            else if (valueType == "string")
            {
                GetMax(firstValue, secondValue);
            }
        }

        static void GetMax(int firstValue, int secondValue, string valueType)
        {
            if (valueType == "int")
            {
                if (firstValue > secondValue)
                {
                    Console.WriteLine(firstValue);
                }
                else
                {
                    Console.WriteLine(secondValue);
                }
            }
            else if (valueType == "char")
            {
                if (firstValue > secondValue)
                {
                    Console.WriteLine((char)firstValue);
                }
                else
                {
                    Console.WriteLine((char)secondValue);
                }
            }
        }

        static void GetMax(string firstValue, string secondValue)
        {
            for (int i = 0; i < firstValue.Length; i++)
            {
                if (firstValue[i] > secondValue[i])
                {
                    Console.WriteLine(firstValue);
                    break;
                }
                else if (firstValue[i] < secondValue[i])
                {
                    Console.WriteLine(secondValue);
                    break;
                }
            }
        }
    }
}