using MyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    class TooShortNameException : FullNameException
    {
        public TooShortNameException(string text) :
            base($"каждое минимум из двуx символов {text}")
        { }
    }
}
