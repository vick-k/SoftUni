namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new(capacity);
            this.capacity = capacity;
        }

        public int Count
        {
            get { return cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (cars.Exists(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.Exists(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(GetCar(registrationNumber));
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                foreach (string registrationNumber in registrationNumbers)
                {
                    if (cars[i].RegistrationNumber == registrationNumber)
                    {
                        cars.RemoveAt(i);
                        i++;
                    }
                }
            }
        }
    }
}
