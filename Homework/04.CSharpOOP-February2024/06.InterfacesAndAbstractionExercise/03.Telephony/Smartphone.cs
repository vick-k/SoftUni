namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
