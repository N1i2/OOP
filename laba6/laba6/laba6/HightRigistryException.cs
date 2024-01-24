using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    class HightRigistryException : FullNameException
    {
        public HightRigistryException(string text) :
            base($"первые буквы большие {text}")
        { }
    }
}
