namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + FuelConsumptionModifier, tankCapacity)
        {

        }

        public void DriveEmpty(double distance)
        {
            double newFuelConsumption = FuelConsumption - FuelConsumptionModifier;
            double neededFuel = distance * newFuelConsumption;

            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;

                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }
    }
}
