using System;
using System.Linq;

namespace Worcks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int max, int min, int sum, char firstCh) NeedFunkci(int[] numbArr, string text)
            {
                return (numbArr.Max(), numbArr.Min(), numbArr.Sum(), text[0]);
            }

            (int max, int min, int sum, char firstCh) NeedFunkci0(int[] numbArr, string text)
            {
                var result = (-999999, 999999, 0, text[0]);

                for (int i = 0; i < numbArr.Length; i++)
                {
                    if (numbArr[i] > result.Item1)
                        result.Item1 = numbArr[i];
                    if (numbArr[i] < result.Item2)
                        result.Item2 = numbArr[i];

                    result.Item3 += numbArr[i];
                }

                return result;
            }

            Random ranada = new Random();
            int[] numbArray = new int[5];
            bool end = false;

            while (!end)
            {
                Console.Write("Какой раздел:\n" +
                    "(0 - Конец, " +
                    "1 - Типы, " +
                    "2 - Строки, " +
                    "3 - Массивы, " +
                    "4 - Кортежи, " +
                    "5 - Проверки):\n");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        MyTips.Modul();
                        Console.ReadLine();
                        break;

                    case '2':
                        Console.Clear();
                        MyString.Modul();
                        Console.ReadLine();
                        break;

                    case '3':
                        Console.Clear();
                        MyArray.Modul();
                        Console.ReadLine();
                        break;

                    case '4':
                        Console.Clear();
                        MyKorteg.Modul();
                        Console.ReadLine();
                        break;

                    case '5':
                        Console.Clear();
                        MyChecked.Modul();
                        Console.ReadLine();
                        break;

                    case '0':
                        end = true;
                        break;

                    default:
                        Console.WriteLine("Такого нет");
                        break;
                }

                Console.Clear();
            }

            for (int i = 0; i < numbArray.Length; i++)
            {
                numbArray[i] = ranada.Next(-10, 10);
            }

            var nechto = NeedFunkci(numbArray, "hello world");
            var nechto0 = NeedFunkci0(numbArray, "world hello");
            Console.ReadLine();
        }
    }
}