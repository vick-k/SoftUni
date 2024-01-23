namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream originalFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                byte[] firstBuffer = new byte[(originalFile.Length + 1) / 2];
                originalFile.Read(firstBuffer, 0, firstBuffer.Length);

                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Create))
                {
                    partOne.Write(firstBuffer, 0, firstBuffer.Length);
                }

                byte[] secondBuffer = new byte[originalFile.Length / 2];
                originalFile.Read(secondBuffer, 0, secondBuffer.Length);

                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    partTwo.Write(secondBuffer, 0, secondBuffer.Length);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] firstBuffer = null;
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Open))
                {
                    firstBuffer = new byte[partOne.Length];
                    joinedFile.Write(firstBuffer);
                }

                byte[] secondBuffer = null;
                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    secondBuffer = new byte[partTwo.Length];
                    joinedFile.Write(secondBuffer, 0, secondBuffer.Length);
                }
            }
        }
    }
}
