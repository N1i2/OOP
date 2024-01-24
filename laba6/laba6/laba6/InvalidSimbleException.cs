﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    class InvalidSimbleException : TooShortNameException
    {
        public InvalidSimbleException(string text) :
             base($"только латинского алфавита {text}")
        { }
    }
}
