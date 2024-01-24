using System;

namespace MyDevoloper
{
    public class Devoloper
    {
        private enum Otdel
        {
            Маркетинг = 1,
            Разработка,
            Продажи
        }

        private readonly int _id;
        private readonly Otdel _otdel;
        private readonly string _name;

        public Devoloper(string name, int otdel)
        {
            _name = name;
            _otdel = (Otdel)otdel;
            _id = 121 * otdel * 71;
        }

        public void ShowIfo()
        {
            Console.WriteLine($"\nИмя: {_name}");
            Console.Write("Отдел: ");
            if ((int)_otdel < 0 || (int)_otdel > 3)
                Console.WriteLine("Нет информации");
            else
                Console.WriteLine(_otdel);
            Console.WriteLine($"ID: {_id}");
        }
    }
}
