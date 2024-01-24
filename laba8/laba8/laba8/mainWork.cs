using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProger;
using MyMetod;
using System.Diagnostics.Eventing.Reader;
using MyString;
using System.Runtime.Remoting.Messaging;
using System.Threading;

delegate void ChangeScope(Programer[] proger, Random ranada);

namespace workWithDelegat
{
    class mainWork
    {
        static event ChangeScope GetNewName;
        static ChangeScope GetNewMehanik;

        static void Main(string[] args)
        {
            const int PROG_SIZE = 3;

            string[] name = new string[5]
            {
                "Нечто",
                "Что-то_скучное",
                "Красивое название",
                "Привет",
                "Ruft"
            };

            Random ranada = new Random();

            Programer[] prog = new Programer[PROG_SIZE];

            GetNewName = (pro, rana) =>
            {
                bool end = false;

                while (!end)
                {
                    int numb = ranada.Next(0, pro.Length);
                    Console.WriteLine("Меняем имя ");
                    Console.WriteLine("Работаем с программой {0}", (int)(numb + 1));
                    while (true)
                    {
                        int numbName = ranada.Next(0, name.Length);
                        float versia = ranada.Next(-100, 101) / 10f;
                        if (name[numbName] != pro[numb].Name)
                        {
                            pro[numb].Name = name[numbName];
                            if (pro[numb].Versia <= versia)
                            {
                                pro[numb].Versia = versia;
                                end = true;
                            }
                            else
                                Console.WriteLine("Версия не менялась");

                            break;
                        }
                    }

                    HelpStaticMetod.ShowProgerInfo(pro[numb]);
                }
            };

            try
            {
                prog[0] = new Programer(name: name[0], vers: 7.4f,
               operat: new string[] { "Добаление", "Удоление", "Вывод на экран", },
               tehnik: new string[] { "Среда разработки", "Библиотеки" },
               termin: new string[] { "Поле", "Класс", "Делегат", "Цикл" });

                prog[1] = new Programer(name: name[1], vers: 1.2f,
                    operat: new string[] { "Чтение файла", "Запись в файл", "Создание файла" },
                    tehnik: new string[] { "Отладчик", "Система контроля версии" },
                    termin: new string[] { "Условие", "Битмассив", "Рекурсия", "Функция" });

                prog[2] = new Programer(name: name[2], vers: 0.8f,
                    operat: new string[] { },
                    tehnik: new string[] { },
                    termin: new string[] { });

                foreach (var item in prog)
                {
                    HelpStaticMetod.ShowProgerInfo(item);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < ranada.Next(5, 9); i++)
            {
                switch (ranada.Next(0, 3))
                {
                    case 0:
                        GetNewMehanik += HelpStaticMetod.ChangeOperation;
                        break;
                    case 1:
                        GetNewMehanik += HelpStaticMetod.ChangeTehnik;
                        break;
                    case 2:
                        GetNewMehanik += HelpStaticMetod.ChangeTermin;
                        break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            GetNewName?.Invoke(prog, ranada);
            GetNewMehanik?.Invoke(prog, ranada);

            Console.ForegroundColor = ConsoleColor.White;
            string text = "Hell,o .how? ARe!!! you";
            string text2 = "Hall,o .how? ERe!!! you";
            string text3 = "Hell,o .how? ERe!!! you";

            Console.WriteLine($"Изначально {text}");

            Action<string> creanNotZnackWorld = (txt) =>
            {
                WorkWithString.DeleteAllZnack(ref txt);
                WorkWithString.CreatOneWord(ref txt);
                text = txt;
            };

            Func<string, string> fence = (txt) =>
            {
                txt = WorkWithString.CreatFence(txt);
                return WorkWithString.ShowMirror(txt);
            };

            Predicate<string> locSimbleA = (txt) =>
            {
                return WorkWithString.LocateCharA(txt);
            };

            creanNotZnackWorld(text);

            string newStr = fence(text);

            Console.WriteLine($"Старый {text}");
            Console.WriteLine($"Новый {newStr}");

            Console.WriteLine((locSimbleA(text)) ? "Симвл \'A\' есть в строке 1" : "Симвла \'A\' нет в строке 1");
            Console.WriteLine((locSimbleA(text2)) ? "Симвл \'A\' есть в строке 2" : "Симвла \'A\' нет в строке 2");
            Console.WriteLine((locSimbleA(text3)) ? "Симвл \'A\' есть в строке 3" : "Симвла \'A\' нет в строке 3");
        }
    }
}
