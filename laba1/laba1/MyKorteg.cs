using System;

namespace Worcks
{
    class MyKorteg
    {
        public static void Modul()
        {
            //создание + ()
            (int numb, string firstStr, char simble, string seconStr, ulong uNumb)
                MyKart = (4, "hello", 'k', "world", 20000);

            //Вывод
            Console.WriteLine($"{MyKart.numb} / " +
                $"{MyKart.firstStr} / " +
                $"{MyKart.simble} / " +
                $"{MyKart.seconStr} / " +
                $"{MyKart.uNumb}");

            Console.Write("Введиете какие хотите видить:");

            ShowKart(Convert.ToInt32(Console.ReadLine()), MyKart);

            //распаковка второй способ
            int number = MyKart.numb;
            string[] firstS = { MyKart.firstStr, MyKart.seconStr };
            char simble = MyKart.simble;
            ulong unsigNumb = MyKart.uNumb;

            //сравнение
            var kurt1 = (2, 3);
            var kurt2 = (43, 102);
            var kurt3 = (2, '3');

            if (kurt1 == kurt2)
                Console.WriteLine("Однаковые");
            else
                Console.WriteLine("Не однаковые");

            if (kurt1 == kurt3)
                Console.WriteLine("Однаковые");
            else
                Console.WriteLine("Не однаковые");
        }

        static void ShowKart(int schet, (int, string, char, string, ulong) kort)
        {
            var s = new object[5];

            //первый способ
            s[0] = kort.Item1;
            s[1] = kort.Item2;
            s[2] = kort.Item3;
            s[3] = kort.Item4;
            s[4] = kort.Item5;

            for (int i = 0; schet > 0; schet /= 10)
            {
                i = schet % 10;

                if (i > 5 || i < 1)
                    continue;

                Console.WriteLine(s[i - 1]);
            }
        }
    }
}