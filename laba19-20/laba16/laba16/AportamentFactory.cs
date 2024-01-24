using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstaractFactory
{
    abstract class AportamentFactory
    {
        public abstract Aportamens GetAportClass();
        public abstract FlatHous GetVid();
    }
}
