using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    sealed class Island : Name, IForGet
    {
        public Island(string name, bool live, Land land, Sea sea)
        {
            ObjName = name;
            Live_in = live;
            this.land = land;
            this.sea = sea;
        }

        private bool live_in = false;
        private Land land;
        private Sea sea;

        public bool Live_in
        {
            get => live_in;
            set => live_in = value;
        }

        public Land LandInfo
        {
            get => land;
        }

        public Sea SeaInfo
        {
            get => sea;
        }

        public override void showName()
        {
            base.showName();
            Console.WriteLine(sea.ObjName);
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n\nНазвание: Остров {0}", ObjName);
            Console.WriteLine("Площадь острова: {0} км", land.Teritory);
            Console.WriteLine(((Live_in) ? "Пригоден " : "Не пригоден ") + "для жизни");
            Console.WriteLine("На острове {0} климот", land.LocAreal);
            Console.WriteLine("Остров окружает море {0} м", sea.ObjName);
            Console.WriteLine("Максимальная глубина этого моря: {0}", sea.MaxDepth);
            Console.WriteLine("Море занимает площадь {0} км", sea.WaterInfo.Teritory);
            Console.WriteLine("Количество фауны в воде: {0}%", sea.WaterInfo.Flora);
        }

        public override string ToString()
        {
            return "Остров\n" + ObjName;
        }
    }
}
