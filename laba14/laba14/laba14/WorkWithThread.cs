using System;
using System.IO;
using System.Threading;

namespace MyThread
{
    static class WorkWithThread
    {
        static WorkWithThread()
        {
            adres = "..\\..\\..\\file";
            adres1 = "..\\..\\..\\Number.txt";

            key = new object();
        }

        static private string adres;
        static private string adres1;
        static private object key;

        static public void ShowDataFSecondThread()
        {
            Thread th = new Thread(() =>
            {
                int j;
                Console.Write("Введите количесто чисел: ");
                if (!int.TryParse(Console.ReadLine(), out j) || j > 7)
                    j = 0;

                if (j < 0)
                    j = Math.Abs(j);

                Console.WriteLine();
                using (StreamWriter file = File.CreateText(adres + "2.txt"))
                {
                    for (int i = 1; i < (j + 1); i++)
                    {
                        if (i == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (i == 2)
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        else if (i == 3)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else if (i == 4)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else if (i == 5)
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        else if (i == 6)
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        else
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;

                        Console.Write(i);
                        file.Write(i);
                        Thread.Sleep(400);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                }
            });

            th.Start();

            Console.WriteLine(th.Name ?? "Нет имени");
            Console.WriteLine(th.ThreadState);
            Console.WriteLine(th.Priority);
            Console.WriteLine(th.ManagedThreadId);

            th.Join();
        }

        static public void WorkWithTwoThread()
        {
            int countNumb;

            Console.Write("Введите количество цифр: ");
            if (!int.TryParse(Console.ReadLine(), out countNumb) || countNumb <= 0 || countNumb > 20)
                countNumb = 10;

            using (StreamWriter file = File.CreateText(adres1))
            {
                Thread firstTh = new Thread(() =>
                {
                    ShowNumbers(file, countNumb, 0);
                })
                {
                    Priority = ThreadPriority.BelowNormal
                };
                Thread secondTh = new Thread(() =>
                {
                    ShowNumbers(file, countNumb, 1);
                });

                Console.WriteLine(firstTh.Priority);
                Console.WriteLine(secondTh.Priority);

                firstTh.Start();
                secondTh.Start();

                if (countNumb % 2 == 0)
                firstTh.Join();
                else
                secondTh.Join();
            }
        }

        static private void ShowNumbers(StreamWriter file, int n, int how)
        {
            if (how != 0 && how != 1)
                how = 0;

            lock (key)
            for (int i = how; i < n; i += 2)
            {
                Console.WriteLine(i + 1);
                file.WriteLine(i + 1);

                Thread.Sleep((how == 0) ? 10 : 11);

                    Monitor.Pulse(key);
                    Monitor.Wait(key);
            }
        }
    }
}