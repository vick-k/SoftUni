﻿namespace CopyBinaryFile
{
    using System;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream inputFile = new FileStream(inputFilePath, FileMode.Open);

            byte[] buffer = new byte[2048];
            int bytesRead;

            using FileStream outputFile = new FileStream(outputFilePath, FileMode.Create);

            while ((bytesRead = inputFile.Read(buffer, 0, buffer.Length)) > 0)
            {
                outputFile.Write(buffer, 0, bytesRead);
            }
        }
    }
}