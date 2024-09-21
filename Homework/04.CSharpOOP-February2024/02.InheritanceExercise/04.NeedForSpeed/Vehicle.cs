namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            DefaultFuelConsumption = defaultFuelConsumption;
        }

        public double DefaultFuelConsumption { get => 1.25; set => defaultFuelConsumption = value; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }
    }
}
