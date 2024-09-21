namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                string[] firstInputLines = reader1.ReadToEnd().Split("\r\n").ToArray();

                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    string[] secondInputLines = reader2.ReadToEnd().Split("\r\n").ToArray();

                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        int longerInput = Math.Max(firstInputLines.Length, secondInputLines.Length);

                        if (firstInputLines.Length == longerInput)
                        {
                            for (int i = 0; i < secondInputLines.Length; i++)
                            {
                                writer.WriteLine(firstInputLines[i]);
                                writer.WriteLine(secondInputLines[i]);
                            }

                            for (int i = secondInputLines.Length; i < firstInputLines.Length; i++)
                            {
                                writer.WriteLine(firstInputLines[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < firstInputLines.Length; i++)
                            {
                                writer.WriteLine(firstInputLines[i]);
                                writer.WriteLine(secondInputLines[i]);
                            }

                            for (int i = firstInputLines.Length; i < secondInputLines.Length; i++)
                            {
                                writer.WriteLine(secondInputLines[i]);
                            }
                        }
                    }
                }
            }
        }
    }
}
