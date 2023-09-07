using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worcks
{
    internal class MyChecked
    {
        public static void Modul()
        {
            first();
            void first()
            {
                int max;
                checked
                {
                    try
                    {
                        max = int.MaxValue;
                        Console.WriteLine(max);
                        max++;
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Перполнение не возможно");
                    }
                }
            }
            Console.ReadLine();

            second();

            void second()
            {
                int max;
                unchecked
                {
                    max = int.MaxValue;
                    Console.WriteLine(max);
                    max++;
                }
            }
        }
    }
}
