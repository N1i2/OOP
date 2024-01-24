using MyMatrx;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Security;

namespace laba15
{
    internal class Start
    {
        static SemaphoreSlim sem = new SemaphoreSlim(0);

        static async Task Main(string[] args)
        {
            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 1 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
            int[][,] matrx = new int[2][,];

            for (int i = 0; i < matrx.Length; i++)
            {
                int[] size = new int[2];

                Console.Clear();
                try
                {
                    for (int j = 0; j < size.Length; j++)
                    {
                        Console.Write("Введите {0} матрицы №{1}:\t", (j == 0) ? "длинну" : "ширину", i + 1);
                        if (!int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out size[j]))
                            throw new Exception("Введенные символы не явяються числом");
                        Console.WriteLine();
                    }

                    matrx[i] = WorkMatrx.GetRendomMatrx(size[0], size[1]);

                    if (i == 1)
                        if (matrx[0].GetLength(1) != matrx[1].GetLength(0))
                            throw new Exception("Error");

                    Console.WriteLine("Все введено правильно");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    if (ex.Message == "Error")
                    {
                        Console.WriteLine("Такие матрицы нельзя перемножить");
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }

                    Console.WriteLine(ex.Message);
                    if (i > -1)
                        i--;
                    Console.ReadKey();
                }
            }

            Console.Clear();

            Console.WriteLine("Первая матрица:");
            WorkMatrx.ShowMattrx(matrx[0]);
            Console.WriteLine("\nВторая матрица:");
            WorkMatrx.ShowMattrx(matrx[1]);

            Stopwatch timer = new Stopwatch();
            Stopwatch timer2 = new Stopwatch();


            Console.WriteLine("\nИтог:");

            try
            {
                timer.Start();
                int[,] result = WorkMatrx.CreatMult(matrx[0], matrx[1]);
                timer.Stop();

                WorkMatrx.ShowMattrx(result);
                Console.Write($"Время затраченое на вычисление произведения:\t{timer.Elapsed}");
                Console.WriteLine();

                timer.Start();
                int[,] result2 = WorkMatrx.CreatMult(matrx[0], matrx[1]);
                timer.Stop();

                WorkMatrx.ShowMattrx(result2);
                Console.Write($"Время затраченое на вычисление произведения:\t{timer.Elapsed}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 2 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh

            Console.ReadKey();
            Console.Clear();

            try
            {
                int[,] result3 = WorkMatrx.CreatMultEager(matrx[0], matrx[1]);
                WorkMatrx.ShowMattrx(result3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 3 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh

            int second = 654489;

            Task<int> less1 = Task<int>.Run(() =>
            {
                return second % 60;
            });
            Task<int> less2 = Task<int>.Run(() =>
            {
                return (second % 3600 - less1.Result) / 60;
            });
            Task<int> less3 = Task<int>.Run(() =>
            {
                return (second - less1.Result - less2.Result * 60) / 3600;
            });

            string time = less3.Result + "." + less2.Result + "." + less1.Result;

            Task.WaitAll(less1, less2);

            Console.WriteLine(time);

            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 4 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh

            Task<int> less41 = Task<int>.Run(() =>
            {
                return new Random().Next(0, 101) % 10;
            });
            Task<int> less42 = Task<int>.Run(() =>
            {
                return new Random().Next(0, 11);
            });

            Task need = Task.WhenAll(less41, less42).ContinueWith(t =>
            {
                Console.WriteLine("Результат первого {0}", less41.Result);
                Console.WriteLine("Результат второго {0}", less42.Result);

                Console.WriteLine((less41.Result == less42.Result) ? "Они рандомно совпали" : "Увы но они не совпали");
            });

            need.Wait();

            Task<int> sec = Task<int>.Run(() => HelpMetod.AwaitResult());

            int lit = await sec;
            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 5 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
            timer.Start();
            HelpMetod.SqwerNumb(1);
            HelpMetod.SqwerNumb(2);
            HelpMetod.SqwerNumb(3);
            timer.Stop();

            Console.WriteLine("Время на изменение строки без паралелей: {0}", timer.Elapsed);

            timer.Start();
            Parallel.For(1, 4, HelpMetod.SqwerNumb);
            timer.Stop();

            Console.WriteLine("Время на изменение строки с паралелей: {0}", timer.Elapsed);

            Parallel.ForEach<string>(
                new List<string>() { "HeL,,o", "HoW.", ",a,,re you" },
                StringChan.RecreatText
                );
            Console.WriteLine('\n');

            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 6 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh

            Parallel.Invoke(HelpMetod.SayHello, HelpMetod.SayWait, HelpMetod.SayBy);

            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 7 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
            Parallel.For(1, 3, HelpMetod.Eho);

            Console.WriteLine("Конец торговли");
            //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh 8 hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
            Task<string> createrA = Task.Run(() =>
            {
                return "От А ";
            });
            Task<string> createrZ = Task.Run(() =>
            {
                return "до Z ";
            });

            await createrA;
            Console.Write(createrA.Result);
            await createrZ;
            Console.WriteLine(createrZ.Result);
        }
    }
}