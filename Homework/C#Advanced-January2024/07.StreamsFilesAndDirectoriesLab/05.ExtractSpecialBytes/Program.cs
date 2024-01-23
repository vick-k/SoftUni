namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                byte[] bytes = reader.ReadToEnd()
                    .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                    .Select(byte.Parse)
                    .ToArray();

                List<byte> occurrences = new List<byte>();

                using (FileStream fs = new FileStream(binaryFilePath, FileMode.Open))
                {

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);

                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (bytes.Contains(buffer[i]))
                        {
                            occurrences.Add(buffer[i]);
                        }
                    }
                }

                using (FileStream output = new FileStream(outputPath, FileMode.Create))
                {
                    output.Write(occurrences.ToArray(), 0, occurrences.Count);
                }
            }
        }
    }
}
