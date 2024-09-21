using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Motorcycle motorcycle = new(15, 20);
            motorcycle.Drive(2);
            Console.WriteLine(motorcycle.Fuel);

            RaceMotorcycle raceMotorcycle = new(25, 30);
            raceMotorcycle.Drive(2);
            Console.WriteLine(raceMotorcycle.Fuel);

            CrossMotorcycle crossMotorcycle = new(20, 35);
            crossMotorcycle.Drive(2);
            Console.WriteLine(crossMotorcycle.Fuel);

            Car car = new(90, 40);
            car.Drive(2);
            Console.WriteLine(car.Fuel);

            FamilyCar familyCar = new(70, 60);
            familyCar.Drive(2);
            Console.WriteLine(familyCar.Fuel);

            SportCar sportCar = new(150, 50);
            sportCar.Drive(2);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
