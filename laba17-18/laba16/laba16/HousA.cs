using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstaractFactory
{
    class HousA : AportamentFactory
    {
        public override Aportamens GetAportClass()
        {
            return new ClassA();
        }

        public override FlatHous GetVid()
        {
            return new HousVid();
        }
    }
}
