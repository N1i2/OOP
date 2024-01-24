using System;

namespace MyPlace
{
    abstract class Land : Place, IForGet
    {
        public Land(int terytory, int location)
        {
             Teritory=terytory;
            LocAreal = (Areal)location;
        }

        public enum Areal
        {
            Засушливый = -2,
            Теплый,
            Нейтральный,
            Прохладный,
            Холодный
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

        sealed public override int Teritory 
        {
            get
            {
                if (terAreal == null)
                    throw new Exception("Данные не были введены");

                return (int)terAreal;
            }
            set
            {
                if (value <= 0)
                    throw new Exception("Такого не может быть");

                terAreal = (uint)(value * value);
            }
        }

        public override ulong VivodID()
        {
            return (ulong)Teritory * (ulong)LocAreal;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Земля занимает площадь {0} км", Teritory);
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
