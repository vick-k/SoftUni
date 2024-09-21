using System.Text;

namespace Problem01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cipheredSpell = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Abracadabra")
            {
                string[] arguments = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string spell = arguments[0];

                if (spell == "Abjuration")
                {
                    cipheredSpell = cipheredSpell.ToUpper();
                    Console.WriteLine(cipheredSpell);
                }
                else if (spell == "Necromancy")
                {
                    cipheredSpell = cipheredSpell.ToLower();
                    Console.WriteLine(cipheredSpell);
                }
                else if (spell == "Illusion")
                {
                    int index = int.Parse(arguments[1]);
                    char letter = char.Parse(arguments[2]);

                    if (index < 0 || index >= cipheredSpell.Length)
                    {
                        Console.WriteLine("The spell was too weak.");
                        continue;
                    }

                    StringBuilder sb = new StringBuilder(cipheredSpell);
                    sb[index] = letter;
                    cipheredSpell = sb.ToString();
                    
                    Console.WriteLine("Done!");
                }
                else if (spell == "Divination")
                {
                    string firstSubstring = arguments[1];
                    string secondSubstring = arguments[2];

                    if (!cipheredSpell.Contains(firstSubstring))
                    {
                        continue;
                    }

                    cipheredSpell = cipheredSpell.Replace(firstSubstring, secondSubstring);

                    Console.WriteLine(cipheredSpell);
                }
                else if (spell == "Alteration")
                {
                    string substring = arguments[1];

                    if (!cipheredSpell.Contains(substring))
                    {
                        continue;
                    }

                    int startIndex = cipheredSpell.IndexOf(substring);
                    cipheredSpell = cipheredSpell.Remove(startIndex, substring.Length);

                    Console.WriteLine(cipheredSpell);
                }
                else // spell is not in the list
                {
                    Console.WriteLine("The spell did not work!");
                }
            }
        }
    }
}
