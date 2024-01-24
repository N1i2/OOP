using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    class Printer
    {
        public virtual string IAmPrinter(MyAbstr abstr)
        {
            return abstr.ToString();
        }
    }
}
