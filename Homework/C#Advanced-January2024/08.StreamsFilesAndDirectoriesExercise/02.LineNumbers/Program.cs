namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = 0;
                int punctuationCount = 0;

                foreach (char c in lines[i])
                {
                    if (char.IsLetter(c))
                    {
                        lettersCount++;
                    }

                    if (char.IsPunctuation(c))
                    {
                        punctuationCount++;
                    }
                }

                lines[i] = $"Line {i + 1}: {lines[i]} ({lettersCount}) ({punctuationCount})";
            }

            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
