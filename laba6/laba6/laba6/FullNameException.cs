using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    class FullNameException : Exception
    {
        public FullNameException(string text) :
            base($"ERROR::ФИО должно состоять из трех слов {text}")
        { }
    }
}
