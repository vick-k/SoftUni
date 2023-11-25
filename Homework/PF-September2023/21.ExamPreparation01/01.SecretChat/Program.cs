namespace _01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] commands = command.Split(":|:");
                string instruction = commands[0];

                if (instruction == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);
                    message = message.Insert(index, " ");

                    Console.WriteLine(message);
                }
                else if (instruction == "Reverse")
                {
                    string substring = commands[1];

                    if (!message.Contains(substring))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    message = message.Remove(message.IndexOf(substring), substring.Length);
                    string reversedSubstring = new string(substring.Reverse().ToArray());
                    message += reversedSubstring;

                    Console.WriteLine(message);
                }
                else if (instruction == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];

                    message = message.Replace(substring, replacement);

                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
