namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wordsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordsCount; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (synonyms.ContainsKey(word))
                {
                    synonyms[word].Add(synonym);
                }
                else
                {
                    synonyms.Add(word, new List<string>());
                    synonyms[word].Add(synonym);
                }
            }

            foreach (KeyValuePair<string, List<string>> kvp in synonyms)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}