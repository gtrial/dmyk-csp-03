﻿using System.IO;

namespace task3
{
    internal static class Program
    {
        private static void Main()
        {
            //Напишите приложение для поиска заданного файла на диске.
            //Добавьте код, использующий класс FileStream и позволяющий просматривать файл в текстовом окне.
            //В заключение добавьте возможность сжатия найденного файла.
            var directoryInfo = new DirectoryInfo(@".");
            directoryInfo.GetFiles();
        }
    }
}