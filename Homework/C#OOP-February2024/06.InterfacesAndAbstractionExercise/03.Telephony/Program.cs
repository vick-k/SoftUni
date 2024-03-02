namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();


            foreach (string phoneNumber in phoneNumbers)
            {
                if (!phoneNumber.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                ICallable phone;

                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                    phone.Call(phoneNumber);
                }
                else if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                    phone.Call(phoneNumber);
                }
            }

            foreach (string website in websites)
            {
                if (website.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                IBrowsable smartphone = new Smartphone();
                smartphone.Browse(website);
            }
        }
    }
}
