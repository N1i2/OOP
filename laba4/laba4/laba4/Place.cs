using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    class Place
    {
        private static ulong allTer;
        static Place()
        {
            allTer = 0;
        }

        protected uint? terAreal = null;

        public int Teritory
        {
            get
            {
                return (int)terAreal;
            }
            set
            {
                if (value <= 0 || value >= 510_100_000)
                    value = 100;

                allTer += (ulong)value;

                terAreal = (uint)value;
            }
        }

        public virtual ulong VivodID()
        {
            return allTer;
        }
    }
}
