using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstaractFactory
{
    internal class FlatC : AportamentFactory
    {
        public override Aportamens GetAportClass()
        {
            return new ClassC();
        }

        public override FlatHous GetVid()
        {
            return new FlatVid();
        }
    }
}
