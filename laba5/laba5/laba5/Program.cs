using MyPlace;
using System;

namespace laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            Sea sea1 = new Sea("Синие", 20_000, 56, 1_300);
            Sea sea2 = new Sea("Приветов", 200, 23, 13_300);
            Continent continent1 = new Continent(name: "ЕврАмерика", teritory: 40_000_000, location: -1, true);
            Continent continent2 = new Continent("Красивый", 200_000, -2, false);
            Island island1 = new Island("Синие", 13_000, 2, false, sea1);
            Island island2 = new Island("Сокровищь", 31_000, 0, true, sea2);
            Island island3 = new Island("Атракцион", 11_000, -2, true, sea1);
            State state1 = new State("Амьрют", 2_000, -2, 130, continent1);
            State state2 = new State("Адобовс", 3_500, 2, 1300, island1);
            State state3 = new State("Алигом", 4_000, -2, 130, continent1);

            state1.GetInfoPres("Ктототам ктототамович", 72);

            sea1.ShowInfo();
            Console.WriteLine();
            continent1.ShowInfo();
            Console.WriteLine();
            island1.ShowInfo();
            Console.WriteLine();
            state1.ShowInfo();
            Console.WriteLine();
            state2.ShowInfo();
            Console.WriteLine();

            string hello = "привет";

            World world = new World();
            world.GetObj = sea1;
            world.GetObj = sea2;
            world.GetObj = hello;
            world.GetObj = continent1;
            world.GetObj = continent2;
            world.GetObj = island1;
            world.GetObj = island2;
            world.GetObj = island3;
            world.GetObj = state1;
            world.GetObj = state2;
            world.GetObj = state3;

            try
            {
                world.ShowAllObj();
                Console.WriteLine();
                world.DeleteObj("Синие", 'i');
                //world.DeleteObj("Синие");
                Console.WriteLine();
                world.ShowAllObj();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Kontrol kontrol = new Kontrol(world);

            Console.WriteLine(kontrol.LocateStates("ЕврАмерика"));
            Console.WriteLine(kontrol.LocateStates("helloyia"));

            Console.WriteLine(kontrol.ColSea());

            kontrol.IslandOrder();   
        }
    }
}