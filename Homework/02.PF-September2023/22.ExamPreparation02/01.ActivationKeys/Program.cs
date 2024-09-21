namespace _01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] commandArr = input
                    .Split(">>>");

                string command = commandArr[0];

                if (command == "Contains")
                {
                    string substring = commandArr[1];

                    if (!rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine("Substring not found!");
                        continue;
                    }

                    Console.WriteLine($"{rawActivationKey} contains {substring}");
                }
                else if (command == "Flip")
                {
                    string secondCommand = commandArr[1];
                    int startIndex = int.Parse(commandArr[2]);
                    int endIndex = int.Parse(commandArr[3]);

                    if (secondCommand == "Upper")
                    {
                        string substring = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                        string upperSubstring = substring.ToUpper();
                        rawActivationKey = rawActivationKey.Replace(substring, upperSubstring);

                        Console.WriteLine(rawActivationKey);
                    }
                    else if (secondCommand == "Lower")
                    {
                        string substring = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                        string lowerSubstring = substring.ToLower();
                        rawActivationKey = rawActivationKey.Replace(substring, lowerSubstring);

                        Console.WriteLine(rawActivationKey);
                    }
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);

                    rawActivationKey = rawActivationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(rawActivationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}
