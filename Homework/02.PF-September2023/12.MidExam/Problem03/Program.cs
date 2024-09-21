namespace Problem03
{
    internal class Program // Chat Logger
    {
        static void Main(string[] args)
        {
            List<string> log = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0] == "Chat")
                {
                    string message = command[1];

                    log.Add(message);
                }
                else if (command[0] == "Delete")
                {
                    string message = command[1];

                    if (log.Contains(message))
                    {
                        log.Remove(message);
                    }
                }
                else if (command[0] == "Edit")
                {
                    string message = command[1];
                    string editedMessage = command[2];

                    if (log.Contains(message))
                    {
                        int index = log.FindIndex(x => x == message);

                        log[index] = editedMessage;
                    }
                }
                else if (command[0] == "Pin")
                {
                    string message = command[1];

                    if (log.Contains(message))
                    {
                        int index = log.FindIndex(x => x == message);

                        string savedMessage = log[index];
                        log.RemoveAt(index);
                        log.Add(savedMessage);
                    }
                }
                else if (command[0] == "Spam")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        log.Add(command[i]);
                    }
                }
            }

            Console.WriteLine(string.Join("\n", log));
        }
    }
}