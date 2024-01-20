namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] arguments = input.Split(", ");
                string direction = arguments[0];
                string carNumber = arguments[1];

                if (direction == "IN")
                {
                    parkingLot.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parkingLot.Remove(carNumber);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
