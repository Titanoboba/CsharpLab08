using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
namespace TestConcole
{


    class Program
    {

        static void Main()
        {
            string catalog = @"C:\Users\Python\source\repos\CsharpLab08";

            string fileName = "animal.xml";

            foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName,
                SearchOption.AllDirectories))
            {
                FileInfo FileInfo;
                try
                {
                    FileInfo = new FileInfo(findedFile);
                    Console.WriteLine(FileInfo.Name + " " + FileInfo.FullName + " " + FileInfo.Length + "_bites" +
                        " Created: " + FileInfo.CreationTime);

                }
                catch //слишком длинное имя файла
                {
                    continue;
                }

            }

            string sourceFile = "animal.xml"; // исходный файл
            string compressedFile = "animal.gz"; // сжатый файл

            async Task CompressAsync(string sourceFile, string compressedFile)
            {
                // поток для чтения исходного файла
                using FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate);
                // поток для записи сжатого файла
                using FileStream targetStream = File.Create(compressedFile);

                // поток архивации
                using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
                await sourceStream.CopyToAsync(compressionStream); // копируем байты из одного потока в другой

                Console.WriteLine($"Compression of file: {sourceFile} completed.");
                Console.WriteLine($"Initial size: {sourceStream.Length}\ncompressed size: {targetStream.Length}");
            }


            // создание сжатого файла
            CompressAsync(sourceFile, compressedFile);




            String line;
            try
            {

                StreamReader myRider = new StreamReader(@"C:\\text.txt");

                line = myRider.ReadLine();

                while (line != null)
                {

                    Console.WriteLine(line);

                    line = myRider.ReadLine();
                }

                myRider.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }


    }
}