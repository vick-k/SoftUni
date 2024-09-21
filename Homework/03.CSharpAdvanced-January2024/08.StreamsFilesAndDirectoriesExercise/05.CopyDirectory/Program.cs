namespace CopyDirectory
{
    using System;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string[] allFiles = Directory.GetFiles(inputPath);
            string[] newFiles = new string[allFiles.Length];

            for (int i = 0; i < allFiles.Length; i++)
            {
                newFiles[i] = allFiles[i].Replace(inputPath, outputPath);
            }

            for (int i = 0; i < allFiles.Length; i++)
            {
                File.Copy(allFiles[i], newFiles[i]);
            }
        }
    }
}
