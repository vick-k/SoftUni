namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new List<Vehicle>();

            int carsTotalHP = 0;
            int trucksTotalHP = 0;
            int carsCount = 0;
            int trucksCount = 0;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo = input
                    .Split();

                string typeOfVehicle = vehicleInfo[0];
                string model = vehicleInfo[1];
                string color = vehicleInfo[2];
                int horsePower = int.Parse(vehicleInfo[3]);

                Vehicle vehicle = new Vehicle();

                vehicle.TypeOfVehicle = char.ToUpper(typeOfVehicle[0]) + typeOfVehicle.Substring(1);
                vehicle.Model = model;
                vehicle.Color = color;
                vehicle.HorsePower = horsePower;

                catalogue.Add(vehicle);

                if (vehicle.TypeOfVehicle == "Car")
                {
                    carsTotalHP += vehicle.HorsePower;
                    carsCount++;
                }
                else // "truck"
                {
                    trucksTotalHP += vehicle.HorsePower;
                    trucksCount++;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle currentModel = catalogue.Find(v => v.Model == command);

                Console.WriteLine(currentModel);
            }

            double carsAverageHP = 1.0 * carsTotalHP / carsCount;
            double trucksAverageHP = 1.0 * trucksTotalHP / trucksCount;

            if (trucksCount == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsAverageHP:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
            else if (carsCount == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHP:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {carsAverageHP:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHP:f2}.");
            }
        }

        public class Vehicle
        {
            public string TypeOfVehicle { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

            public override string ToString()
            {
                return $"Type: {TypeOfVehicle}\n" +
                    $"Model: {Model}\n" +
                    $"Color: {Color}\n" +
                    $"Horsepower: {HorsePower}";
            }
        }
    }
}