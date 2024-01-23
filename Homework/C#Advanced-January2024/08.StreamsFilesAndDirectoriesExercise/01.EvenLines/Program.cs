namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            int counter = 0;
            string line = reader.ReadLine();
            char[] specialChars = { '-', ',', '.', '!', '?' };
            StringBuilder sb = new StringBuilder();

            while (line != null)
            {
                if (counter % 2 == 0)
                {
                    foreach (char c in line)
                    {
                        if (specialChars.Contains(c))
                        {
                            line = line.Replace(c, '@');
                        }
                    }

                    string[] lineArr = line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Reverse()
                        .ToArray();
                    sb.AppendLine(string.Join(' ', lineArr));
                }

                counter++;
                line = reader.ReadLine();
            }

            return sb.ToString();
        }
    }
}
