using MyLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMetod
{
    static class HelpStaticMetod
    {
        public static void ShowInfo(string[] value)
        {
            if (value.Length == 0)
            {
                Console.WriteLine("Таких нет");
                return;
            }

            int schet = 0;
            foreach (var item in value)
            {
                Console.WriteLine($"{++schet} == {item}");
            }
        }

        public static void ShowLine(AirLine[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Red : ConsoleColor.Cyan;
                lines[i].ShowInfo();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
