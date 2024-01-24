using MyMetod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba11
{
    class MyClass:IMetods, IComparable
    {
        public MyClass()
        {

        }
        public MyClass(string hi)
        {
            hello = hi;
        }

        public int five = 5;
        public string hello { get; private set; }
        private string goodBy;
        static int schet = 0;
        public void Hello(string text)
        {
            foreach (var item in text)
            {
                if (item != '|')
                    Console.Write(item);
                else
                    Console.ReadLine();
            }
            Console.WriteLine('\n');
        }
        static public void Schet(int numb)
        {
            int result = 0;

            while (numb>0)
            {
                result += numb % 10;
                numb /= 10;
            }

            Console.WriteLine(result);
        }
        public void Add(int hi)
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Show()
        {
            throw new NotImplementedException();
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
