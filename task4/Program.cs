using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace task4
{
    internal static class Program
    {
        private static void Main()
        {
            var isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            const string directoryName = "TestDirectory";
            var directories = isolatedStorage.GetDirectoryNames(directoryName);
            if (directories.Length == 0)
            {
                isolatedStorage.CreateDirectory(directoryName);
            }

            var isolatedStorageFileStream =
                new IsolatedStorageFileStream(@"" + directoryName + "/test.txt", FileMode.Create, isolatedStorage);

            var streamWriter = new StreamWriter(isolatedStorageFileStream);
            streamWriter.WriteLine("line 1");
            streamWriter.Close();

            var userStream =
                new IsolatedStorageFileStream(@"" + directoryName + "/test.txt", FileMode.Open, isolatedStorage);
            var streamReader = new StreamReader(userStream);
            var fileContent = streamReader.ReadToEnd();
            Console.WriteLine(fileContent);
        }
    }
}