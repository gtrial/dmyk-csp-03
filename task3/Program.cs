using System;
using System.IO;
using System.IO.Compression;

namespace task3
{
    internal static class Program
    {
        private static void Main()
        {
            var directoryInfo = new DirectoryInfo(@".");
            var files = directoryInfo.GetFiles("task3.deps.json");
            foreach (var file in files)
            {
                Console.WriteLine(file.Name + ":");
                var streamReader = new StreamReader(file.Open(FileMode.Open));
                Console.WriteLine(streamReader.ReadToEnd());
                streamReader.Close();

                file.OpenRead().CopyTo(new GZipStream(File.Create(file.Name + ".zip"), CompressionMode.Compress));
            }
        }
    }
}