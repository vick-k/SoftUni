﻿namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle(3, 5);
            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.Draw());

            Shape circle = new Circle(4);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
        }
    }
}
