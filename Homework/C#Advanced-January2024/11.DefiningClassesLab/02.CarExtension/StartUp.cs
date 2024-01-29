namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new();

            car.Make = "Honda";
            car.Model = "Civic";
            car.Year = 1999;
            car.FuelQuantity = 450;
            car.FuelConsumption = 9;
            car.Drive(20);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
