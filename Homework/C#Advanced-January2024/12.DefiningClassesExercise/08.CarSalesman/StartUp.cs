namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new();
            List<Engine> engines = new();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                Engine engine = CreateNewEngine();
                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                Car car = CreateNewCar(engines);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car CreateNewCar(List<Engine> engines)
        {
            string[] arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string carModel = arguments[0];
            string engineModel = arguments[1];

            Car car = new Car();
            car.Model = carModel;
            car.Engine = engines.First(engine => engine.Model == engineModel);

            if (arguments.Length > 2 && char.IsDigit(arguments[2][0]))
            {
                int weight = int.Parse(arguments[2]);
                car.Weight = weight;
            }

            if (arguments.Length > 2 && !char.IsDigit(arguments[2][0]))
            {
                string color = arguments[2];
                car.Color = color;
            }

            if (arguments.Length > 3)
            {
                int weight = int.Parse(arguments[2]);
                string color = arguments[3];
                car.Weight = weight;
                car.Color = color;
            }

            return car;
        }

        private static Engine CreateNewEngine()
        {
            string[] arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string engineModel = arguments[0];
            int power = int.Parse(arguments[1]);

            Engine engine = new Engine();
            engine.Model = engineModel;
            engine.Power = power;

            if (arguments.Length > 2 && char.IsDigit(arguments[2][0]))
            {
                int displacement = int.Parse(arguments[2]);
                engine.Displacement = displacement;
            }

            if (arguments.Length > 2 && !char.IsDigit(arguments[2][0]))
            {
                string efficiency = arguments[2];
                engine.Efficiency = efficiency;
            }

            if (arguments.Length > 3)
            {
                int displacement = int.Parse(arguments[2]);
                string efficiency = arguments[3];
                engine.Displacement = displacement;
                engine.Efficiency = efficiency;

            }

            return engine;
        }
    }
}
