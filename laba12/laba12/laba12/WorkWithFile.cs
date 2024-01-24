using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyProtakol;

namespace MyFile
{
    static class WorkWithFile
    {
        static WorkWithFile()
        {
            lines = 0;
            adressF = "..\\..\\..\\SNE-Log.txt";
        }

        static string adressF;
        static int lines;

        static public void CreatFile()
        {
            using (StreamWriter file = File.CreateText(adressF))
            {
            }
        }
        static public void AppTextFile(string text)
        {
            if (text.Replace(" ", "") == "")
                throw new Exception("Это пустая строка");

            using (StreamWriter file = File.AppendText(adressF))
            {
                file.WriteLine($"{++lines}:\t{text}");
            }

            Protacol.Message();
        }
        static public void AppTextFile(string adres, string text, bool need = true)
        {
            if (text.Replace(" ", "") == "")
                throw new Exception("Это пустая строка");
            if (!File.Exists(adres))
                throw new Exception("Такого файла нет");

            using (StreamWriter file = File.AppendText(adres))
            {
                file.WriteLine($"{text}");
            }

            if (need)
                Protacol.Message();
        }

        static public void DeletTextFile(int line)
        {
            string[] textes;

            using (StreamReader file = File.OpenText(adressF))
            {
                textes = file.ReadToEnd().Split('\n');
                textes = textes.Take(textes.Length - 1).ToArray();

                if (line > textes.Length)
                    throw new IndexOutOfRangeException();

                textes = textes.Select(c => string.Join("", c.Skip(3))).ToArray();
            }

            CreatFile();

            using (StreamWriter file = File.CreateText(adressF))
            {
                for (int i = 0, j = 1; i < lines; i++)
                {
                    if (line == i + 1 && j == 1)
                    {
                        j--;
                        continue;
                    }

                    file.WriteLine($"{i + j}:\t{textes[i]}");
                }
            }

            lines--;
            Protacol.Message(2);
        }
        static public void LocateText(string text)
        {
            if (text.Replace(" ", "") == "")
                throw new Exception("Слово пусто");

            string[] textes;
            List<int> result = new List<int>();

            using (StreamReader file = File.OpenText(adressF))
            {
                textes = file.ReadToEnd().Split('\n').TakeWhile(word => word.Length != 0).ToArray();
            }

            string[] helpText = new string[textes.Length];
            textes.CopyTo(helpText, 0);
            textes = textes.Select(word => string.Join("", word.Skip(3))).ToArray();

            for (int i = 0; i < textes.Length; i++)
                if (textes[i].Contains(text))
                    result.Add(i);

            if (result.Count == 0)
                throw new Exception("Таких нет");

            Console.WriteLine("Все строки содержащие подстроку");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (int i in result)
                Console.WriteLine(helpText[i]);
            Console.ForegroundColor = ConsoleColor.White;

            Protacol.Message(3);
        }
        static public void ShowAllFile()
        {
            using (StreamReader file = File.OpenText(adressF))
            {
                string[] textes = file.ReadToEnd().Split('\n');

                if (textes.Length == 1)
                    throw new Exception("Файл пуст");

                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string text in textes)
                    Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static public string CreateFile(string adres)
        {
            adres += "\\file_0.txt";

            using (File.Create(adres))

                return adres;
        }

        static public void CreatClon(string adres, string newName)
        {
            if (!File.Exists(adres))
                throw new Exception("Такого файла нет");
            if (newName.Replace(" ", "") == "")
                throw new Exception("Новое имя не может быть пустым");

            string[] help = adres.Split('\\');
            string newAdres = string.Join("\\", help.Take(help.Length - 1));

            File.Copy(adres, newAdres + '\\' + newName + ".txt");
            File.Decrypt(newAdres);

            File.Delete(adres);
        }

        static public void CopyOnlyTxt(string newAdres, string oldAdres)
        {
            DirectoryInfo dir = new DirectoryInfo(oldAdres);
            FileInfo[] files = dir.GetFiles("*.txt");

            if (files.Length == 0)
                throw new Exception("В файле нет txt документов");

            int numb = 0;

            foreach (var item in files)
                File.Copy(item.FullName, newAdres + "\\file%" + (++numb) + ".txt");
        }
    }
}
