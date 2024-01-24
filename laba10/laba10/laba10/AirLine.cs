using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLine
{
    enum airplaneTip
    {
        ТУ = 0,
        ИЛ,
        Airbus,
        Boeing
    };
    enum dayOfWeek
    {
        Понедельник = 1,
        Вторник,
        Стреда,
        Четверг,
        Пятница,
        Суббота,
        Вокресенье
    }

    class AirLine
    {
        static AirLine()
        {
            Rise = 0;
        }

        public AirLine(string name, string where, double time, int tip, int day)
        {
            Rise++;
            Name = (name != "") ? name : $"Airplan {Rise}";
            rise = Rise;
            Punkt = (where != "") ? where : "Домой";
            GetTime(time);
            GetTip(tip);
            GetDay(day);
        }

        public string Name { get;private set; }
        public string time { get; private set; }
        public double chackTime { get;private set; }
        public airplaneTip tip { get; private set; }
        public dayOfWeek day { get; private set; }
        public int rise { get; private set; }
        public string Punkt { get; private set; }

        private static int Rise;

        private void GetTime(double ti)
        {
            if(ti<0)
                ti=Math.Abs(ti);

            int hour = (int)ti;
            int minute = (int)Math.Round((ti-(double)hour)*100d);

            while(minute>=60)
            {
                hour++;
                minute -= 60;
            }

            while (hour >= 24)
                hour -= 24;

            chackTime = (double)hour + (double)(minute / 100d);

            time = hour + ((minute!=0)?( " : " + minute):" ровно");
        }
        private void GetTip(int tip)
        {
            if(tip<0)
            tip=Math.Abs(tip);

            while (tip > 3)
                tip -= 4;

            this.tip = (airplaneTip)tip;
        }
        private void GetDay(int day)
        {
            if (day == 0)
            {
                this.day = (dayOfWeek)(++day);
                return;
            }

            if(day<0)
            day = Math.Abs(day);

            while (day > 7)
                day-= 7;

            this.day = (dayOfWeek)day;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Рейс: {rise}");
            Console.WriteLine($"Летит в: {Punkt}");
            Console.WriteLine($"Тип самолета: {tip}");
            Console.WriteLine($"День вылита: {day}");
            Console.WriteLine($"Время вылита: {time}");
        }
    }
}
