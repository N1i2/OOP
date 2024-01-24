using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlace;

namespace laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            Land land = new Land(25_000, 1);
            Water water = new Water(300_000, 59);
            Sea sea = new Sea("Приветов", 5_000, water);
            Continent continent = new Continent("Хороший", 150_000_000, land);
            Island island = new Island("Сокровищ", true, land, sea);
            State state1 = new State("Государственное", 550_000, continent);
            State state2 = new State("Монархическое", 44_000_000,
                new Island("Всех кто кто то", false, new Land(500_000, -1),
                new Sea("Черно-красное", 2_000, new Water(3_000, 2))));
            string state3 = "Привет";

            try
            {
                land.ShowInfo();
                water.ShowInfo();
                sea.ShowInfo();
                continent.ShowInfo();
                island.ShowInfo();
                state1.ShowInfo();

                StateShow(state2);
                StateShow(state3);

                Console.WriteLine('\n');
                sea.showName();
                Console.WriteLine('\n');
                island.showName();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Test test = new Test();

                Console.WriteLine(test.LocHowUse());
                Console.WriteLine(((IForGet)test).LocHowUse());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            ShowToString(land);
            ShowToString(water);
            ShowToString(sea);
            ShowToString(continent);
            ShowToString(island);
            ShowToString(state1);

            Console.WriteLine();

            object[] mass = { land, island, state1 };
            Printer print = new Printer();


            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write($"{i + 1}: ");
                if (mass[i] is MyAbstr er)
                {
                    Console.WriteLine(print.IAmPrinter((MyAbstr)mass[i]));
                    continue;
                }
                Console.WriteLine($"Не наследует абстрактный класс");
            }

            Console.ReadLine();
        }

        static void StateShow(object state)
        {
            IForGet objStat = state as IForGet;

            if (objStat == null)
                Console.WriteLine("\n\nНет государства");
            else
                objStat.ShowInfo();
        }

        static void ShowToString(object obj)
        {
            Console.WriteLine("\n".PadRight(50, '='));
            Console.WriteLine(obj.ToString());
            Console.WriteLine("\n".PadLeft(50, '='));
        }
    }
}