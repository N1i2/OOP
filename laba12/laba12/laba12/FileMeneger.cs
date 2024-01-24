using MyDirictory;
using MyDisck;
using MyFile;
using System;
using System.IO;
using System.IO.Compression;

namespace MyMenej
{
    static class FileMeneger
    {
        static FileMeneger()
        {
            rebit = "\t\t{\\__/}\n\t\t( *-*)\n\t\t/ >a<\\";
        }

        static public string rebit;

        static public void CreatDirik(string diskName)
        {
            string[] names = ShowDiskInfo.GetNames();
            string need = null;

            foreach (var item in names)
                if (item == diskName)
                {
                    need = item;
                    break;
                }

            if (need == null)
                throw new Exception("Такого диска нет");

            ShowDirictory.ShowAllFile(need);
            ShowDirictory.ShowAllDiric(need);

            need = ShowDirictory.CreatDiric(need, "универ\\OOP\\laba12\\file1");
            need = WorkWithFile.CreateFile(need);

            WorkWithFile.AppTextFile(need, rebit, false);

            Console.ReadLine();

            WorkWithFile.CreatClon(need, "file_1");
        }
        static public void RecreatDiric(string newAdres, string oldAdres)
        {
            if (!Directory.Exists(oldAdres))
                throw new Exception("Указаный файл не действителен");
            if (newAdres.Replace(" ", "") == "")
                throw new Exception("Адрес не может быть пустым");

            newAdres = ShowDirictory.CreatDiric(newAdres, "\\file2");

            WorkWithFile.CopyOnlyTxt(newAdres, oldAdres);

            if (Directory.Exists(newAdres + "\\..\\file_3"))
            {
                string adres = newAdres + "\\..\\file_3";
                DirectoryInfo dir = new DirectoryInfo(adres);

                foreach (var item in dir.GetFiles())
                    File.Delete(item.FullName);

                Directory.Delete(adres);
            }

            Directory.Move(newAdres, newAdres + "\\..\\file_3");
        }
        static public void CreatZip(string adres)
        {
            if (!Directory.Exists(adres))
                throw new Exception("Такого католога нет");

            ZipFile.CreateFromDirectory(adres, adres + "\\..\\second.zip");
        }
        static public void RezipFile(string adresZip, string adresRezip)
        {
            ZipFile.ExtractToDirectory(adresZip, adresRezip);
        }
    }
}