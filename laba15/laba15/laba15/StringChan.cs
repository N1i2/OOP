using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba15
{
    static class StringChan
    {
        static public void RecreatText(string text)
        {
            text = text.ToLower();
            text = text.Replace(",", "");
            if (text[text.Length - 1] != '.')
                text += '.';

            text += " ";
            Console.Write(text); ;
        }
    }
}
