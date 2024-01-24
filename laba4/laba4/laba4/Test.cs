using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    class Test : MyAbstr, IForGet
    {
        public override string LocHowUse()
        {
            return "Абстр. класс";
        }

        string IForGet.LocHowUse()
        {
            return "Интерфейс";
        }

        public override void showName()
        {
            throw new NotImplementedException();
        }
        void IForGet.ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
}
