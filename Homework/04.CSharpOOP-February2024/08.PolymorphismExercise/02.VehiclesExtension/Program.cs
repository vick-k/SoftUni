namespace _02.VehiclesExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();
            int commandsCount = int.Parse(Console.ReadLine());

            double carFuel = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            double truckFuel = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            double busFuel = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Car car = new Car(carFuel, carLitersPerKm, carTankCapacity);
            Truck truck = new Truck(truckFuel, truckLitersPerKm, truckTankCapacity);
            Bus bus = new Bus(busFuel, busLitersPerKm, busTankCapacity);

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArguments = Console.ReadLine().Split();
                string command = commandArguments[0];
                string vehicle = commandArguments[1];

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.Drive(double.Parse(commandArguments[2]));
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(double.Parse(commandArguments[2]));
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Drive(double.Parse(commandArguments[2]));
                    }
                }
                else if (command == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(commandArguments[2]));
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(double.Parse(commandArguments[2]));
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(double.Parse(commandArguments[2]));
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(double.Parse(commandArguments[2]));
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
