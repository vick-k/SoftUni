using System;
using System.Text.RegularExpressions;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double squareArea = Math.Pow(squareSide, 2);
                
                Console.WriteLine($"{squareArea:F3}");
            }
            else if (figure == "rectangle")
            {
                double rectangleSideA = double.Parse(Console.ReadLine());
                double rectangleSideB = double.Parse(Console.ReadLine());
                double rectangleArea = rectangleSideA * rectangleSideB;

                Console.WriteLine($"{rectangleArea:F3}");
            }
            else if (figure == "circle")
            {
                double circleRadius = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * Math.Pow(circleRadius, 2);

                Console.WriteLine($"{circleArea:F3}");
            }
            else if (figure == "triangle")
            {
                double triangleSide = double.Parse(Console.ReadLine());
                double triangleHeight = double.Parse(Console.ReadLine());
                double tringleArea = triangleSide * triangleHeight / 2;

                Console.WriteLine($"{tringleArea:F3}");
            }       
        }
    }
}
