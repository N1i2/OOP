using MyDisck;
using System;
using System.IO;

namespace MyDirictory
{
    static class ShowDirictory
    {
        static private DirectoryInfo CreatDir(string adres)
        {
            DirectoryInfo diric = new DirectoryInfo(adres);

            if (!diric.Exists)
                throw new Exception("Такого каталога нет");

            return diric;
        }
        static public void ShowAllFile(string adres)
        {
            DirectoryInfo diric = CreatDir(adres);

            Console.WriteLine("\nВсе файлы в котологе");
            bool est = false;
            foreach (var item in diric.GetFiles())
            {
                est = true;
                Console.WriteLine(item.Name);
            }

            if (!est)
                Console.WriteLine("Файлов нет");
        }
        static public void ShowDateCreat(string adres)
        {
            DirectoryInfo diric = CreatDir(adres);

            Console.WriteLine("\nВремя создания: {0}", diric.CreationTime);
        }
        static public void ShowColPodKotol(string adres)
        {
            DirectoryInfo diric = CreatDir(adres);

            Console.WriteLine("\nУ котолога {0} подкотологов", diric.GetDirectories().Length);
        }
        static public void ShowAllTopKotol(string adres)
        {
            DirectoryInfo diric = CreatDir(adres);

            DriveInfo[] disk = DriveInfo.GetDrives();
            bool end = false;

            Console.WriteLine("\nВсе родительские котологи");
            while (!end)
            {
                diric = diric.Parent;

                end = ShowDiskInfo.LocateName(diric.Name);

                Console.WriteLine(diric.Name);
            }
        }
        static public void ShowAllDiric(string adres)
        {
            DirectoryInfo diric = CreatDir(adres);

            foreach (var item in diric.GetDirectories())
                Console.WriteLine(item.Name);
        }
        static public string CreatDiric(string adres, string name)
        {
            adres += name;

            if (Directory.Exists(adres))
            {
                DirectoryInfo dir = new DirectoryInfo(adres);

                foreach (var item in dir.GetFiles())
                    File.Delete(item.FullName);

                Directory.Delete(adres);
            }

            Directory.CreateDirectory(adres);

            return adres;
        }
    }
}
