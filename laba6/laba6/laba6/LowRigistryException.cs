using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    class LowRigistryException : HightRigistryException
    {
        public LowRigistryException(string text) :
            base($"а все остальные маленькие {text}")
        { }
    }
}