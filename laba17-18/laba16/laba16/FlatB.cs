using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstaractFactory
{
    internal class FlatB : AportamentFactory
    {
        public override Aportamens GetAportClass()
        {
            return new ClassB();
        }

        public override FlatHous GetVid()
        {
            return new FlatVid();
        }
    }
}
