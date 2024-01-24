using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    abstract class Place
    {
        private string name;
        private static ulong allTer;
        protected uint? terAreal = null;

        static Place()
        {
            allTer = 0;
        }

        abstract public int Teritory
        {
            get;
            set;
        }

        public string Name
        {
            get => name;
            set
            {
                if(name==string.Empty)
                    name = "Name";
                else
                    name= value;
            }
        }

        public virtual ulong VivodID()
        {
            return allTer;
        }
    }
}
