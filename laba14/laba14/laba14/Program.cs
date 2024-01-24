using System;
using MyProcess;
using MyDomen;
using MyThread;
using MyTimer;

namespace laba14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //number 1 ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt
            Console.WriteLine("\nЗадание 1");
            try
            {
                WorkWithProces.WriteAllInform();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //number 2 ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt
            Console.WriteLine("\nЗадание 2");
            try
            {
                WorkWithDomen.ShowInfoCurrent();
                Console.WriteLine();
                WorkWithDomen.ShowInfrNewDomen("Hello.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //number 3 ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt
            Console.WriteLine("\nЗадание 3");
            try
            {
                WorkWithThread.ShowDataFSecondThread();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //number 4 ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt
            Console.WriteLine("\nЗадание 4");
            try
            {
                WorkWithThread.WorkWithTwoThread();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //number 5 ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt
            Console.WriteLine("\nЗадание 5");
            try
            {
                TimerLesen.WaitEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}