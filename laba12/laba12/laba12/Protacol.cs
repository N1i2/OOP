using MyFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyProtakol
{
    static class Protacol
    {
        static Protacol()
        {
            doing = 0;
            adressProt = "..\\..\\..\\Protacol.txt";
        }

        static string adressProt;
        static uint doing;

        static public void CreatProtacl()
        {
            using (StreamWriter file = File.AppendText(adressProt))
            {
                file.WriteLine("\t\tПРОТОКОЛ\n");
            }
            WorkWithFile.CreatFile();
        }
        static public void Message(int messNumb = 1)
        {
            if (messNumb < 1 || messNumb > 3)
                return;

            string[] message =
            {
                "Данные были добавлены",
                "Данные были удолены",
                "Производился поиск данных"
            };

            string name = Path.GetFullPath(adressProt);

            using (StreamWriter file = File.AppendText(adressProt))
            {
                doing++;
                file.WriteLine($"[{++doing}] [{DateTime.Now}] [{name}]");
                file.WriteLine($"ОПОВЕЩЕНИЕ:\t{message[messNumb - 1]}\n");
            }
        }

        static private (string, string)[] GetProtacol()
        {
            List<(string time, string whatDo)> result = new List<(string time, string whatDo)>();

            using (StreamReader file = File.OpenText(adressProt))
            {
                string[] lines = file.ReadToEnd().Split('\n');
                string time;
                string what;

                for (int i = 0; i < lines.Length; i++)
                    if (lines[i] != "" && lines[i][0] == '[')
                    {
                        time = string.Join("", lines[i++].SkipWhile(chr => chr != ']').Skip(3).TakeWhile(chr => chr != ']'));
                        what = string.Join("", lines[i].SkipWhile(chr => chr != '\t').Skip(1));
                        result.Add((time, what));
                    }
            }

            return result.ToArray();
        }

        static public void ShowDayProtakol(string day)
        {
            var date = GetProtacol();

            string[] chack = date.Select(item => string.Join("", item.Item1.TakeWhile(chr => chr != ' '))).ToArray();

            Console.WriteLine("Вывод всех протоколов на дату {0}", day);
            for (int i = 0; i < chack.Length; i++)
                if (chack[i] == day)
                    Console.WriteLine(date[i].Item2);
        }

        static public void ShowTimeProtacol(int hour)
        {
            var date = GetProtacol();

            string[] chack = date.Select(item => string.Join("", item.Item1.SkipWhile(chr => chr != ' ').TakeWhile(chr => chr != ':'))).ToArray();

            Console.WriteLine("Вывод всех протоколов в часу {0}", hour);
            for (int i = 0; i < chack.Length; i++)
                if (Convert.ToInt32(chack[i]) == hour)
                    Console.WriteLine($"{date[i].Item1} == {date[i].Item2}");
        }

        static public void ShowWordProtacol(string word)
        {
            var date = GetProtacol();

            string[] rules = date.Select(item => item.Item2).ToArray();

            Console.WriteLine("Вывод всех протоколов по слову {0}", word);
            for (int i = 0; i < rules.Length; i++)
                if (rules[i].Contains(word))
                    Console.WriteLine($"{date[i].Item1} == {date[i].Item2}");
        }

        static public void ShowCol()
        {
            Console.WriteLine(GetProtacol().Length);
        }

        static public void DeleteOldProtacol()
        {
            var date = GetProtacol();

            string[] chack = date.Select(item => string.Join("", item.Item1.SkipWhile(chr => chr != ' ').TakeWhile(chr => chr != ':'))).ToArray();
            string nowT = string.Join("", DateTime.Now.ToString().SkipWhile(chr => chr != ' ').TakeWhile(chr => chr != ':'));

            using (StreamWriter file = File.CreateText(adressProt))
            {
                file.WriteLine("\t\tПРОТОКОЛ\n");

                for (int i = 0; i < chack.Length; i++)
                    if (chack[i] == nowT)
                        file.WriteLine($"[{i}][{date[i].Item1}]\nОПОВЕЩЕНИЕ:\t{date[i].Item2}\n");
            }
        }
    }
}
