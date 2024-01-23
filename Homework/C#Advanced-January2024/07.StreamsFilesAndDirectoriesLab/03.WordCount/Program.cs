namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordsReader = new StreamReader(wordsFilePath))
            {
                string[] wordsArr = wordsReader.ReadToEnd().Split();

                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    Dictionary<string, int> outputWords = new Dictionary<string, int>();

                    string[] text = textReader.ReadToEnd().ToLower().Split(new char[] { ' ', '.', ',', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in wordsArr)
                    {
                        int count = text.Where(w => w == word).Count();
                        outputWords.Add(word, count);
                    }

                    outputWords = outputWords.OrderByDescending(w => w.Value).ToDictionary(w => w.Key, w => w.Value);

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        foreach (var word in outputWords)
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
