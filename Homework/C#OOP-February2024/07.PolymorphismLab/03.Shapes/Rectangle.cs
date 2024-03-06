namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return (width + height) * 2;
        }

        public override string Draw()
        {
            return $"{base.Draw()} {GetType().Name}";
        }
    }
}
