using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLine
{
    enum airplaneTip
    {
        ТУ = 1,
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

    partial class AirLine
    {
        class Vlog
        {
            AirLine airline=new AirLine();
        }

        public readonly int firstReis;
        private static int col = 0;
        const string ERROR = " введен(о) не коректно";
        public string nameEndPoint { get; }
        public int numberReis { get; }
        public int? startTime { get; set; } = null;
        public airplaneTip? aTip { get; set; } = null;
        public dayOfWeek? workDay { get; set; } = null;
        readonly bool umposibleDate;

        static AirLine()
        {
            Console.WriteLine("Использование Airline\n");
        }

        private AirLine()
        {
            Console.WriteLine("HELLO");
        }

        public AirLine(string namePoint, int reis = 1)
        {
            umposibleDate = true;
            col++;
            firstReis = reis;
            nameEndPoint = namePoint;
            numberReis = reis;
        }

        public AirLine(string namePoint, int reis, int time, int tip, int day)
        {
            col++;
            if (reis <= 0)
            { 
                umposibleDate = false;
                col--;
                Console.WriteLine("Рейс" + ERROR);
                return;
            }
            if (time < 0 || (time / 100) > 23 || (time % 100) > 59)
            {
                umposibleDate = false;
                col--;
                Console.WriteLine("Время" + ERROR);
                return;
            }

            if (tip < 0 || tip > 4)
            {
                umposibleDate = false;
                col--;
                Console.WriteLine("Тип самолета" + ERROR);
                return;
            }

            if (day < 0 || day > 7)
            {
                umposibleDate = false ;
                col--;
                Console.WriteLine("День недели" + ERROR);
                return;
            }

            umposibleDate = true;
            firstReis = reis;
            nameEndPoint = namePoint;
            numberReis = reis;
            startTime = time;
            aTip = (airplaneTip)tip;
            workDay = (dayOfWeek)day;
        }

        public static void ShowInfo(ref AirLine air)
        {
            Console.WriteLine('\n');
            if (!air.umposibleDate)
            {
                Console.WriteLine("Данные этого рейса были введены не верно");
                Console.WriteLine('\n');
                return;
            }

            Console.Write($"Самолет рейса {air.numberReis} вылитает в {air.nameEndPoint} ");
            if (air.aTip != null)
                Console.WriteLine($"в {air.workDay} в {air.startTime / 100} часов, {air.startTime%100} минут");
            Console.WriteLine('\n');
        }

        public override bool Equals(object obj)
        {
            AirLine air=obj as AirLine;
            if(air==null||GetType()!=obj.GetType())
                return false;
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (int)(firstReis*numberReis/(int)aTip);
        }

        public override string ToString()
        {
            ShowCol();
            return "";
        }

        ~AirLine()
        {

        }
    }
}
