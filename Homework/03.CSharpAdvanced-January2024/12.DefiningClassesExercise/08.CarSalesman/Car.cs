using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");

            if (Engine.Displacement == 0)
            {
                sb.AppendLine("    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            }

            if (Engine.Efficiency == null)
            {
                sb.AppendLine("    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            }

            if (Weight == 0)
            {
                sb.AppendLine("  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {Weight}");
            }

            if (Color == null)
            {
                sb.AppendLine("  Color: n/a");
            }
            else
            {
                sb.AppendLine($"  Color: {Color}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
