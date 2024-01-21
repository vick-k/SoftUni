namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int usernamesCount = int.Parse(Console.ReadLine());

            HashSet<string> users = new HashSet<string>();

            for (int i = 0; i < usernamesCount; i++)
            {
                users.Add(Console.ReadLine());
            }

            foreach (string username in users)
            {
                Console.WriteLine(username);
            }
        }
    }
}
