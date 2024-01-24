using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstaractFactory
{
    class FlatVid: FlatHous
    {
        public override string VidFlat()
        {
            return "Квартира";
        }
    }
}
