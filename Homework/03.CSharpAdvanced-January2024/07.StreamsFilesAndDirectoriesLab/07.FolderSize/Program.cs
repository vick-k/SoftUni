namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            decimal size = 0;

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] filesInfo = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo file in filesInfo)
            {
                size += file.Length;
            }

            size = size / 1024;

            File.WriteAllText(outputFilePath, size.ToString());
        }
    }
}
