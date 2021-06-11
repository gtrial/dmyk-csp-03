using System;
using System.IO;

namespace task2
{
    internal static class Program
    {
        private static void Main()
        {
            var fileInfo = new FileInfo("test.txt");
            var fileStream = fileInfo.Create();
            Console.WriteLine(fileInfo.FullName);
            Console.WriteLine(fileInfo.Attributes.ToString());
            Console.WriteLine(fileInfo.CreationTime);
            fileStream.WriteByte((byte) 123);
            var streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine("text line");
            streamWriter.Close();
            fileStream.Close();
            fileStream = fileInfo.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            Console.WriteLine(fileStream.ReadByte());
            var streamReader = new StreamReader(fileStream);
            string output;
            while ((output = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(output);
            }

            Console.WriteLine(streamReader.ReadLine());
            //fileInfo.Delete();
        }
    }
}