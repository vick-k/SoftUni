namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base (fuelQuantity, fuelConsumption + FuelConsumptionModifier, tankCapacity)
        {
            
        }

        public override void Refuel(double fuel)
        {
            if (fuel + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }

            base.Refuel(fuel * 0.95);
        }
    }
}
