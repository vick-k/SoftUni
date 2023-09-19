using System;
using System.Data.Common;

namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input
            double num1 = int.Parse(Console.ReadLine());
            double num2 = int.Parse(Console.ReadLine());
            string oper = Console.ReadLine();

            //Finding the result type (even or odd)
            string resultType = "";
            double numSum = num1 + num2;
            double numSubtract = num1 - num2;
            double numMultiply = num1 * num2;
            double numDivide = num1 / num2;
            double numModulo = num1 % num2;

            if (oper == "+")
            {
                if (numSum % 2 == 0)
                {
                    resultType = "even";
                }
                else
                {
                    resultType = "odd";
                }
            }
            else if (oper == "-")
            {
                if (numSubtract % 2 == 0)
                {
                    resultType = "even";
                }
                else
                {
                    resultType = "odd";
                }
            }
            else if (oper == "*")
            {
                if (numMultiply % 2 == 0)
                {
                    resultType = "even";
                }
                else
                {
                    resultType = "odd";
                }
            }

            //Print output
            if (oper == "+")
            {
                Console.WriteLine($"{num1} + {num2} = {numSum} - {resultType}");
            }
            else if (oper == "-")
            {
                Console.WriteLine($"{num1} - {num2} = {numSubtract} - {resultType}");
            }
            else if (oper == "*")
            {
                Console.WriteLine($"{num1} * {num2} = {numMultiply} - {resultType}");
            }
            else if (oper == "/")
            {
                if (num2 != 0)
                {
                    Console.WriteLine($"{num1} / {num2} = {numDivide:f2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
            }
            else
            {
                if (num2 != 0)
                {
                    Console.WriteLine($"{num1} % {num2} = {numModulo}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
            }
        }
    }
}
