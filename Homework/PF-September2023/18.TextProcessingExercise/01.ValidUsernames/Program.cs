namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ");

            foreach (var user in usernames)
            {
                if (user.Length < 3 || user.Length > 16)
                {
                    continue;
                }

                if (user.All(ch => char.IsLetterOrDigit(ch) || ch == '-' ||  ch == '_'))
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}