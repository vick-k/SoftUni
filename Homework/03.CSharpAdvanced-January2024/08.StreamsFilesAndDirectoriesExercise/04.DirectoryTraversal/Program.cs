namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            var reportContent = TraverseDirectory(path);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static Dictionary<string, Dictionary<string, double>> TraverseDirectory(string inputFolderPath)
        {
            string[] allFiles = Directory.GetFiles(inputFolderPath);
            Dictionary<string, Dictionary<string, double>> reportedFiles = new();

            for (int i = 0; i < allFiles.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(allFiles[i]);

                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                double size = fileInfo.Length / 1024.0;

                if (!reportedFiles.ContainsKey(extension))
                {
                    reportedFiles.Add(extension, new Dictionary<string, double>());
                }

                reportedFiles[extension].Add(name, size);
            }

            reportedFiles = reportedFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            return reportedFiles;
        }

        public static void WriteReportToDesktop(Dictionary<string, Dictionary<string, double>> reportedFiles, string reportFileName)
        {
            using StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName);

            foreach (var item in reportedFiles)
            {
                writer.WriteLine($"{item.Key}");

                foreach (var file in item.Value.OrderBy(x => x.Value))
                {
                    writer.WriteLine($"--{file.Key} - {file.Value}kb");
                }
            }
        }
    }
}
