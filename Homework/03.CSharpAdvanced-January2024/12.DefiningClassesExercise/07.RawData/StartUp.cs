namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new() { Speed = engineSpeed, Power = enginePower};
                Cargo cargo = new() { Type = cargoType, Weight = cargoWeight};
                Tire[] tires =
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)
                };

                Car car = new(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(car => car.Cargo.Type == "fragile")
                    .Where(car => car.Tires.Any(tire => tire.Pressure < 1))
                    .ToList();
            }
            else if (command == "flammable")
            {
                cars = cars
                    .Where(car => car.Cargo.Type == "flammable")
                    .Where(car => car.Engine.Power > 250)
                    .ToList();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
