using System;
using System.Timers;

namespace MyTimer
{
    static class TimerLesen
    {
        static TimerLesen()
        {
            count = 1;

            text = new string[5];

            text[0] = "Нажми на любую кнопку";
            text[1] = "Ну нажми на кнопку";
            text[2] = "Да нажми уже";
            text[3] = "НАЖИМАЙ";
            text[4] = "Ну ты и лентяй";
        }

        static private string[] text;
        static private int count;

        static public void WaitEnd()
        {
            System.Timers.Timer timer = new System.Timers.Timer(3000);
            timer.Elapsed += SchetSec;

            timer.Start();

            Console.WriteLine(text[0]);
            Console.ReadKey();

            timer.Stop();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n {\\_/}\n (*-*)\n />0<\\");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("С");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("п");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("а");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("с");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("и");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("б");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("о\n");

            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }

        private static void SchetSec(object sender, ElapsedEventArgs e)
        {
            if (count >= 4)
            {
                Console.WriteLine(text[count]);
                Environment.Exit(0);
            }

            Console.WriteLine(text[count++]);
        }
    }
}