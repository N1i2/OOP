using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba15
{
    static class HelpMetod
    {
        static Random ranada = new Random();
        static BlockingCollection<string> tovar = new BlockingCollection<string>();

        static public void Eho(int how)
        {
            if (how == 1)
                Parallel.For(1, 6, GetProdukt);
            else
                Parallel.For(1, 11, SellProdukt);
        }
        static public void GetProdukt(int prod)
        {
            string[] tov = { "A", "B", "C" };

            while (true)
            {
                int t= ranada.Next(100, 1000);
                Thread.Sleep(t);

                int index = ranada.Next(0, tov.Length);

                string result = tov[index]+$", предоставил №{prod}";

                Console.WriteLine(result);
                tovar.Add(result);

                if(tovar.Count>=10)
                {
                    Console.WriteLine($"Склад полон");
                    break;
                }
            }
        }
        static public void SellProdukt(int prod)
        {
            while (true)
            {
                int t = ranada.Next(100, 1000);
                Thread.Sleep(t);

                string? result;
                if(tovar.TryTake(out result))
                    Console.WriteLine($"Покупатель №{prod} взял продукт {result}");
                else
                {
                    Console.WriteLine($"Покупатель №{prod} ушел");
                    break;
                }
            }
        }
        static public void SqwerNumb(int numb)
        {
            Console.WriteLine($"{numb}^2 == {numb*numb}");
        }
        static public void SayHello()
        {
            Console.WriteLine("Hello");
            Thread.Sleep(1000);
        }
        static public void SayWait()
        {
            Console.WriteLine("Wait");
            Thread.Sleep(1000);
        }
        static public void SayBy()
        {
            Console.WriteLine("Byby");
            Thread.Sleep(1000);
        }
        static public int AwaitResult()
        {
            Task.Delay(1000).GetAwaiter().GetResult();

            return 0;
        }

    }
}