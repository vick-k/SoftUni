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

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
