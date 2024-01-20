
namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string reservationNumber;
            while ((reservationNumber = Console.ReadLine()) != "PARTY")
            {
                if (FirstCharIsDigit(reservationNumber[0]))
                {
                    vipGuests.Add(reservationNumber);
                }
                else
                {
                    regularGuests.Add(reservationNumber);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (FirstCharIsDigit(input[0]))
                {
                    vipGuests.Remove(input);
                }
                else
                {
                    regularGuests.Remove(input);
                }
            }

            Console.WriteLine(regularGuests.Count + vipGuests.Count);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }

        private static bool FirstCharIsDigit(char symbol)
        {
            if ("1234567890".Contains(symbol))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
