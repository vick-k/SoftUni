using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string validEmojiPattern = @"(\*\*|::)(?<letters>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            string input = Console.ReadLine();

            List<Emoji> validEmojisList = new List<Emoji>();

            MatchCollection validEmojisCollection = Regex.Matches(input, validEmojiPattern);
            MatchCollection digitsCollection = Regex.Matches(input, digitsPattern);
            
            ulong threshold = 1;

            foreach (Match digit in digitsCollection)
            {
                threshold *= ulong.Parse(digit.Value);
            }

            foreach (Match match in validEmojisCollection)
            {
                uint coolness = 0;

                for (int i = 0; i < match.Groups["letters"].Value.Length; i++)
                {
                    coolness += match.Groups["letters"].Value[i];
                }

                Emoji emoji = new Emoji();
                emoji.Name = match.Groups["letters"].Value;
                emoji.CodeName = match.Value;
                emoji.Coolness = coolness;
                validEmojisList.Add(emoji);
            }

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{validEmojisList.Count} emojis found in the text. The cool ones are:");

            foreach (Emoji emoji in validEmojisList)
            {
                if (emoji.Coolness > threshold)
                {
                    Console.WriteLine($"{emoji.CodeName}");
                }
            }
        }
    }

    class Emoji
    {
        public string Name { get; set; }
        public string CodeName { get; set; }
        public uint Coolness { get; set; }
    }
}
