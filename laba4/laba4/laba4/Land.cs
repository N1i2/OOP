using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    sealed class Land : Place, IForGet
    {
        public enum Areal
        {
            Засушливый = -2,
            Теплый,
            Нейтральный,
            Прохладный,
            Холодный
        }

        public Land(int ter, int loc)
        {
            Teritory = ter;
            LocAreal = (Areal)loc;
        }

        private Areal? locashen = null;

        public Areal LocAreal
        {
            get
            {
                if (locashen == null)
                    throw new Exception("error: Климот не был выставлен");

                return (Areal)locashen;
            }
            set
            {
                if ((int)value < -2 || (int)value > 2)
                    return;

                locashen = value;
            }
        }

        public override ulong VivodID()
        {
            return (ulong)Teritory * (ulong)LocAreal;
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n\nЗемля занимает площадь {0} км", Teritory);
            Console.WriteLine("На данной теретории: {0} климот", LocAreal);
        }

        public override string ToString()
        {
            return "Земля\n" + Teritory;
        }

        public string LocHowUse()
        {
            throw new NotImplementedException();
        }
    }
}
