using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    sealed class Water : Place, IForGet
    {
        public Water(int ter, int flor)
        {
            Teritory = ter;
            Flora = flor;
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

        public override ulong VivodID()
        {
            return (ulong)(Teritory * Flora * 97);
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n\nВода занимает площадь {0} км", Teritory);
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
