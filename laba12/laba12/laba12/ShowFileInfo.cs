using System;
using System.IO;

namespace MyFile
{
    static class ShowFileInfo
    {
        static public void ShowFullPath(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            Console.WriteLine($"\n{Path.GetFullPath(path)}");
        }
        static public void ShowFullInfo(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            FileInfo info = new FileInfo(path);

            Console.WriteLine("\nИнфа о файле");
            Console.WriteLine($"Имя: {info.Name}");
            Console.WriteLine($"Размер: {info.Length}");
            Console.WriteLine($"Расшерение: {info.Extension}");
        }
        static public void ShowDate(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            FileInfo file = new FileInfo(path);

            Console.WriteLine($"\nФайл создан {file.CreationTime}");
            Console.WriteLine($"Внисены изменения {file.LastAccessTime}");
        }
    }
}
