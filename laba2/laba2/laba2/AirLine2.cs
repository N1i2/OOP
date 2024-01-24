using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLine
{
    partial class AirLine
    {
        public static void ShowCol()
        {
            Console.WriteLine("\n".PadLeft(50, '='));
            Console.WriteLine("Класс хранит информацию о:");
            Console.WriteLine("Пункте назначения(обяз),");
            Console.WriteLine("Номере рейса(обяз),");
            Console.WriteLine("Типе самолета(необ),");
            Console.WriteLine("Времени и дате вылита(необ)");
            Console.WriteLine($"Количество созданных обьектов на данный момент класса: {col}");
            Console.WriteLine("\n".PadRight(50, '='));
        }

        const int reservPlas = 30;

        public static void Reservation(out int free)
        {
            free = reservPlas;
        }
    }
}
