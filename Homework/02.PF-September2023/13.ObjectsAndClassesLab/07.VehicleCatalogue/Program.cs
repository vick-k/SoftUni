using System.Reflection;

namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Truck> trucksList = new List<Truck>();
            List<Car> carsList = new List<Car>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] vehicleInfo = input.Split("/");

                string type = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];

                if (type == "Car")
                {
                    int horsePower = int.Parse(vehicleInfo[3]);

                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;

                    carsList.Add(car);
                }
                else // type == "Truck"
                {
                    int weight = int.Parse(vehicleInfo[3]);

                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;

                    trucksList.Add(truck);
                }
            }

            carsList = carsList.OrderBy(x => x.Brand).ToList();
            trucksList = trucksList.OrderBy(x => x.Brand).ToList();

            if (carsList.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (Car car in carsList)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucksList.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in trucksList)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

        public class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }

        public class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
    }
}