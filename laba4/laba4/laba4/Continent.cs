using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    sealed class Continent : Name, IForGet
    {
        public Continent(string name, int allTer, Land land)
        {
            ObjName = name;
            this.land = land;
            AllContinent = allTer;
        }

        private int? allTeretory = null;
        private Land land;

        public int? AllContinent
        {
            get
            {
                if (allTeretory == null)
                    throw new Exception("error: Общая площадь контенента неизвестна");

                return allTeretory;
            }
            set
            {
                if (value <= 1_000 || value > 250_000_000)
                    throw new Exception("error: Общая площать контенента не может быть такой");

                if (value < land.Teritory)
                    throw new Exception("error: Площадь материка не может быть меньше чем площадь суши");

                allTeretory = value;
            }
        }

        public int LandTer
        {
            get => land.Teritory;
        }

        public Land.Areal LandAreal
        {
            get => land.LocAreal;
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n\nНазвание: {0} контенент", ObjName);
            Console.WriteLine("Полная площадь контенента: {0} км", AllContinent);
            Console.WriteLine("Из них суши: {0} км", land.Teritory);
            Console.WriteLine("Этот контенент находиться в: {0} кимоте", land.LocAreal);
        }

        public override string ToString()
        {
            return "Контенент\n" + ObjName;
        }
    }
}
