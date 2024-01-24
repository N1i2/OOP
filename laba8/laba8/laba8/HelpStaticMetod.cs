using MyProger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMetod
{
    static class HelpStaticMetod
    {
        public static void ChangeOperation(Programer[] proger, Random ranada)
        {
            string[] operation =
            {
                "Добавление",
                "Удоление",
                "Вывод на экран",
                "Чтение файла",
                "Запись в файл",
                "Создание файла",
                "Сортировка",
                "Создание дилигата",
            };

            int numb = ranada.Next(0, proger.Length);

            Console.WriteLine("Меняем операции");
            Console.WriteLine("Работаем с программой {0}", (int)(numb + 1));

            ChangeAll(proger[numb].Operation, operation[ranada.Next(0, operation.Length)], ranada.Next(0, 2));

            ShowProgerInfo(proger[numb]);
        }

        public static void ChangeTehnik(Programer[] proger, Random ranada)
        {
            string[] tehnologe =
            {
                "Среда разработки",
                "Библиотеки",
                "Отладчик",
                "Система контроля версии",
                "Компилятор",
                "Компоновщик",
            };

            int numb = ranada.Next(0, proger.Length);

            Console.WriteLine("Меняем технологии");
            Console.WriteLine("Работаем с программой {0}", (int)(numb + 1));

            ChangeAll(proger[numb].Tehnolage, tehnologe[ranada.Next(0, tehnologe.Length)], ranada.Next(0, 2));

            ShowProgerInfo(proger[numb]);
        }

        public static void ChangeTermin(Programer[] proger, Random ranada)
        {
            string[] termin =
            {
                "Поле",
                "Класс",
                "Делегат",
                "Цикл",
                "Условие",
                "Рекурсия",
                "Функция",
                "Исключение",
                "Метод",
                "Конструктор",
                "IL код"
            };

            int numb = ranada.Next(0, proger.Length);

            Console.WriteLine("Меняем термины");
            Console.WriteLine("Работаем с программой {0}", (int)(numb + 1));

            ChangeAll(proger[numb].Termin, termin[ranada.Next(0, termin.Length)], ranada.Next(0, 2));

            ShowProgerInfo(proger[numb]);
        }

        private static void ChangeAll(List<string> proger, string change, int ad_d_el)
        {
            if(ad_d_el==0)
            {
                if(!proger.Contains(change))
                {
                    Console.WriteLine("Попытка удоления {0} не увенчалась успехом", change);
                    return;
                }

                proger.Remove(change);

                return;
            }

            if(proger.Contains(change))
            {
                Console.WriteLine("Попытка добавления {0} не увенчалась успехом", change);
                return;
            }

            proger.Add(change);
        }

        public static void ShowProgerInfo(Programer proger)
        {
            if(proger.schetCol==1)
                Console.ForegroundColor = ConsoleColor.Green;
            else if(proger.schetCol == 2)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Имя: {0}, Врсия: {1}", proger.Name, proger.Versia);

            Console.Write("Операции: ");
            if (proger.Operation.Count != 0)
            {
                foreach (var item in proger.Operation)
                    Console.Write($"{item} | ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("Пусто");

            Console.Write("Технологии: ");
            if (proger.Tehnolage.Count != 0)
            {
                foreach (var item in proger.Tehnolage)
                    Console.Write($"{item} | ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("Пусто");

            Console.Write("Термины: ");
            if (proger.Termin.Count != 0)
            {
                foreach (var item in proger.Termin)
                    Console.Write($"{item} | ");
                Console.WriteLine();
            }
            else
                Console.WriteLine("Пусто");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n".PadRight(60, '=') + '\n');
        }
    }
}
