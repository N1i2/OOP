using System;
using System.Linq;

namespace Worcks
{
    class MyTips
    {
        public static void Modul()
        {
            //Создать вывести и ввести
            int numb = 5;
            string text = "hello world";
            char sim = 'A';
            bool logikValue = true;
            float drobNumber = 7.44f;

            byte bit = 7;
            sbyte mBit = -100;

            short shrt = 30;
            ushort mShrt = 0;

            uint mNumb = 100;

            long lon = 9000;

            decimal dec = 1000.1M;
            double dbl = 100.1d;

            object ne = 45d;

            ulong uLlon = (ulong)(bit + mBit + shrt + mShrt
                - (double)dec + mNumb + lon - dbl);

            ShowDataTips(
                numb: numb, hello: text, simble: sim, check: logikValue, value: drobNumber
                );
            Console.WriteLine();
            WriteDataTips
                (
                numb: ref numb, hello: ref text, simble: ref sim, check: ref logikValue, value: ref drobNumber
                );

            //Явное преобразование
            //пеервый
            Console.WriteLine((Convert.ToBoolean(numb)) ? "Число не равно 0" : "Число равно 0");

            //второй
            if (!int.TryParse(Convert.ToString(sim), out int newNumber))
                Console.WriteLine("Введенный симвл не переводиться в цифры");
            else
                Console.WriteLine("Введенный символ может быть числом");

            //тертий 
            numb = Convert.ToInt32(logikValue);

            //четвертый
            char nine = '9';
            Console.WriteLine(Convert.ToInt32(Convert.ToString(nine)) + 5);

            //пятый
            Console.WriteLine(Convert.ToDouble(Convert.ToString(nine)) / 2);

            //неявное преобразование
            //первое
            byte testBite = 1;
            short secondNumb = testBite;

            //второе
            numb = secondNumb;

            //третье
            Console.WriteLine((drobNumber + numb));

            //четвертый
            double secondValue = drobNumber;

            //пятый 
            drobNumber = numb;

            //упаковка и распаковка
            object help = numb;
            numb = (int)help;

            //Работа с var
            int[] myArr = Enumerable.Range(1, 10).ToArray();

            foreach (var item in myArr)
            {
                Console.WriteLine(item);
            }

            //nullable
            int? newNumb = null;
            Console.WriteLine(newNumb);
            //var 

            var k = "hello";
            //k = 'm';
            Console.WriteLine(k);
        }

        static void ShowDataTips(in int numb, in string hello, in char simble, in bool check, in float value)
        {
            Console.WriteLine($"int: {numb} \nstring: {hello} \nchar: {simble} \nbool: {check} \ndouble: {value}");
            Console.WriteLine("int: {0} \nstring: {1} \nchar: {2} \nbool: {3} \ndouble: {4}", numb, hello, simble, check, value);
        }

        static void WriteDataTips(ref int numb, ref string hello, ref char simble, ref bool check, ref float value)
        {
            Console.Write("int: ");
            numb = Convert.ToInt32(Console.ReadLine());
            Console.Write("sting: ");
            hello = Console.ReadLine();
            Console.Write("char: ");
            simble = char.Parse(Console.ReadLine());
            Console.Write("bool: ");
            check = bool.Parse(Console.ReadLine());
            Console.Write("double: ");
            value = float.Parse(Console.ReadLine());

            Console.WriteLine();
            ShowDataTips
                (
                numb: numb, hello: hello, simble: simble, check: check, value: value
                );
        }
    }
}