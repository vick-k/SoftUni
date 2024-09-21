using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine()
                .Split(", ");

            string patternLetters = @"[A-Za-z]";
            string patternDigits = @"\d";

            Regex regexName = new Regex(patternLetters);
            Regex regexDistance = new Regex(patternDigits);

            List<Participant> participantsList = new List<Participant>();

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder participantName = new StringBuilder();

                foreach (Match match in regexName.Matches(input))
                {
                    participantName.Append(match.Value);
                }

                string currentName = participantName.ToString();

                if (!participants.Contains(currentName))
                {
                    continue;
                }

                if (!participantsList.Exists(p => p.Name == currentName))
                {
                    Participant participant = new Participant();

                    participant.Name = currentName;

                    participantsList.Add(participant);
                }

                int distance = 0;

                foreach (Match match in regexDistance.Matches(input))
                {
                    distance += int.Parse(match.Value);
                }

                participantsList.Find(p => p.Name == currentName).Distance += distance;
            }

            participantsList = participantsList.OrderByDescending(p => p.Distance).ToList();

            Console.WriteLine($"1st place: {participantsList[0].Name}");
            Console.WriteLine($"2nd place: {participantsList[1].Name}");
            Console.WriteLine($"3rd place: {participantsList[2].Name}");
        }
    }

    class Participant
    {
        public string Name { get; set; }
        public int Distance { get; set; }
    }
}
