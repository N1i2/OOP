using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    sealed class State : Name, IForGet
    {
        public State(string name, long popul, Continent cont)
        {
            ObjName = name;
            Popular = popul;
            continent = cont;
            island = null;
        }
        public State(string name, long popul, Island isl)
        {
            ObjName = name;
            Popular = popul;
            island = isl;
            continent = null;
        }

        private ulong? popular = null;
        private Continent continent;
        private Island island;

        public long? Popular
        {
            get
            {
                if (popular == null)
                    throw new Exception("error: Численность населения не была введена");

                return (long)popular;
            }
            set
            {
                if (value <= 0 || value > 8_000_000_000)
                    throw new Exception("error: Такое количество юде невозможно");

                popular = (ulong)value;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n\nНазвание: {0} государство", ObjName);
            Console.WriteLine("Население: {0} человек", Popular);

            if (island == null)
            {
                Console.WriteLine("Это государство находиться в: {0} кимоте", continent.LandAreal);
                Console.WriteLine("Расположен: {0} материк", continent.ObjName);
                Console.WriteLine("Полная площадь контенента: {0} км", continent.AllContinent);
                Console.WriteLine("Из них суши: {0} км", continent.LandTer);
                return;
            }

            Console.WriteLine("Расположение: Остров {0}", island.ObjName);
            Console.WriteLine("Площадь острова: {0} км", island.LandInfo.Teritory);
            Console.WriteLine(((island.Live_in) ? "Густо " : "Не густо ") + "населен");
            Console.WriteLine("На острове {0} климот", island.LandInfo.LocAreal);
            Console.WriteLine("Остров окружает море {0}", island.SeaInfo.ObjName);
            Console.WriteLine("Максимальная глубина этого моря: {0}", island.SeaInfo.MaxDepth);
            Console.WriteLine("Море занимает площадь {0} км", island.SeaInfo.WaterInfo.Teritory);
            Console.WriteLine("Количество фауны в воде: {0}%", island.SeaInfo.WaterInfo.Flora);
        }

        public override string ToString()
        {
            return "Государство\n" + ObjName;
        }
    }
}
