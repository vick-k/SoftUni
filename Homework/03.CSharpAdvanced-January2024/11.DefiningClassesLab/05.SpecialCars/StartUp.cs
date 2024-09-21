namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new();
            List<Engine> engines = new();
            List<Car> cars = new();
            List<Car> specialCars = new();

            string tiresInput;
            while ((tiresInput = Console.ReadLine()) != "No more tires")
            {
                string[] arguments = tiresInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int year1 = int.Parse(arguments[0]);
                double pressure1 = double.Parse(arguments[1]);
                int year2 = int.Parse(arguments[2]);
                double pressure2 = double.Parse(arguments[3]);
                int year3 = int.Parse(arguments[4]);
                double pressure3 = double.Parse(arguments[5]);
                int year4 = int.Parse(arguments[6]);
                double pressure4 = double.Parse(arguments[7]);

                Tire[] tire =
                {
                    new Tire(year1, pressure1),
                    new Tire(year2, pressure2),
                    new Tire(year3, pressure3),
                    new Tire(year4, pressure4),
                };

                tires.Add(tire);
            }

            string engineInput;
            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] arguments = engineInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int horsePower = int.Parse(arguments[0]);
                double cubicCapacity = double.Parse(arguments[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            string finalInput;
            while ((finalInput = Console.ReadLine()) != "Show special")
            {
                string[] arguments = finalInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string make = arguments[0];
                string model = arguments[1];
                int year = int.Parse(arguments[2]);
                double fuelQuantity = double.Parse(arguments[3]);
                double fuelConsumption = double.Parse(arguments[4]);
                int engineIndex = int.Parse(arguments[5]);
                int tiresIndex = int.Parse(arguments[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                double tiresPressureSum = car.Tires.Sum(t => t.Pressure);
                bool validPressure;
                if (tiresPressureSum >= 9 && tiresPressureSum <= 10)
                {
                    validPressure = true;
                }
                else
                {
                    validPressure = false;
                }

                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && validPressure)
                {
                    specialCars.Add(car);
                }
            }

            foreach (Car car in specialCars)
            {
                car.Drive(20);
                car.PrintCar();
            }
        }
    }
}
