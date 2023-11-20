namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int lastDashIndex = filePath.LastIndexOf('\u005c');
            int dotIndex = filePath.LastIndexOf('.');

            string fileName = filePath.Remove(dotIndex).Substring(lastDashIndex + 1);
            string fileExtension = filePath.Substring(dotIndex + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}