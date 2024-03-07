namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base (fuelQuantity, fuelConsumption + FuelConsumptionModifier)
        {
            
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
