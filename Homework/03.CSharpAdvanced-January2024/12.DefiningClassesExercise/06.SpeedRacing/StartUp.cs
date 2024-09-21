namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carInfo[2]);

                Car car = new() { Model = model, FuelAmount = fuelAmount, FuelConsumptionPerKilometer = fuelConsumptionPerKilometer };
                cars.Add(car);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = arguments[1];
                double amountOfKm = double.Parse(arguments[2]);

                Car currentCar = cars.First(car => car.Model == carModel);
                
                currentCar.DriveCar(amountOfKm);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
