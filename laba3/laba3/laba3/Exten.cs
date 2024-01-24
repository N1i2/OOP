using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStacks;

namespace MyExtention
{
    static class Exten
    {
        public static int LocatePart(this string text)
        {
            int col = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.')
                    col++;
            }

            if (text[text.Length - 1] != '.')
                col++;

            return col;
        }

        public static double StackAverage(this MyStack<int> steck)
        {
            if(steck.Index==0)
                return 0;

            double sum = 0;

            for (int i = 0; i < steck.Index; i++)
            {
                sum += steck.getSteck(i);
            }

            return (sum / steck.Index);
        }
    }
}
