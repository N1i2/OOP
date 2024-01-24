using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyPlace
{
    class Name : MyAbstr
    {
        protected string name = null;

        public string ObjName
        {
            get
            {
                return name;
            }
            set
            {
                if (value == string.Empty)
                {
                    name = "Безымянный";
                    return;
                }
                name = value;
            }
        }
        public static new bool ReferenceEquals(object objA, object objB)
        {
            if (new Random().Next(0, 1) == 1)
                return true;
            return false;
        }

        public override string LocHowUse()
        {
            throw new NotImplementedException();
        }

        public override void showName()
        {
            Console.WriteLine(ObjName);
        }
    }
}
