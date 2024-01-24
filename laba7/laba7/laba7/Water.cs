using System;

namespace MyPlace
{
    abstract class Water : Place, IForGet
    {
        public Water(int terytory, int flora)
        {
            Teritory = terytory;
            Flora = flora;
        }

        private byte? floraProsent = null;

        public int Flora
        {
            get
            {
                if (floraProsent == null)
                    throw new Exception("error: Процент флоры в воде не был введен");

                return (int)floraProsent;
            }
            set
            {
                if (value < 0 || value >= 100)
                    throw new Exception("error: Такой процент флоры в воде невозможен");

                floraProsent = (byte)value;
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

                terAreal = (uint)(value*Math.PI*Math.PI);
            }
        }

        public override ulong VivodID()
        {
            return (ulong)(Teritory * Flora * 97);
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Вода занимает площадь {0} км", Teritory);
            Console.WriteLine("Количество фауны в воде: {0}%", Flora);
        }

        public string LocHowUse()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Вода\n" + Teritory;
        }
    }
}
