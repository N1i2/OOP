using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MyLine;

namespace laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AirLine first = new AirLine();
            AirLine second = new AirLine("hello");
            AirLine threed = new AirLine("hello", 5);
            AirLine forh = new AirLine("goodby", -1, 24_35, 5, 9);
            AirLine five = new AirLine("itog", 5, 10_00, 4, 2);

            //forh.firstReis = 8;

            AirLine kk = null;

            object hi = 300;

            Help hg = new Help();
            Console.WriteLine(forh.Equals(second));
            Console.WriteLine(five.Equals(null));
            Console.WriteLine(five.Equals(hg));
            Console.WriteLine(five.Equals(five));

            AirLine.ShowInfo(ref threed);
            AirLine.ShowInfo(ref forh);
            AirLine.ShowInfo(ref five);

            AirLine.ShowCol();

            int reserv;

            AirLine.Reservation(out reserv);

            AirLine[] airLinesMas = new AirLine[5];
            string[] endP = { "нидерланды", "америка", "океан" };
            Random ranada = new Random();

            for (int i = 0; i < 5; i++)
            {
                airLinesMas[i] = new AirLine(namePoint: endP[ranada.Next(0, 3)],
                    reis: i + 1,
                    time: (ranada.Next(0, 24) * 100 + ranada.Next(0, 60)),
                    tip: ranada.Next(1, 4),
                    day: ranada.Next(1, 7)
                    );
            }

            var ananimTip = new {endPoint="Домой", reis=999, time=20_20, tip="ddd", day="Фторник" };



            Console.ReadLine();
            Console.Clear();

            for (int i = 0; i < 5; i++)
            {
                AirLine.ShowInfo(ref airLinesMas[i]);
            }

            string lokate = endP[ranada.Next(0, 3)];
            bool loc = false;
            Console.WriteLine("Рейсы в {0}:", lokate);
            for (int i = 0; i < 5; i++)
            {
                if (airLinesMas[i].nameEndPoint==lokate)
                {
                    loc=true;
                    Console.WriteLine($"Рейс №{i+1}");
                }
            }
            if(!loc)
                Console.WriteLine("Туда никто не летит");

            loc=false;
            dayOfWeek locateDay=(dayOfWeek)ranada.Next(1, 7);

            Console.WriteLine("Рейсы вылит которых в {0}:", locateDay);
            for (int i = 0; i < 5; i++)
            {
                if (airLinesMas[i].workDay== locateDay)
                {
                    loc = true;
                    Console.WriteLine($"Рейс №{i + 1} вылетают в {locateDay}");
                }
            }
            if (!loc)
                Console.WriteLine("В этот день никто не летит");

        }
    }
}
