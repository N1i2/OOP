using System;
using MyStacks;
using MyPlace;

namespace laba7
{
    class Program
    {
        static void Main()
        {
            const string ADRESS = "..\\..\\..\\exe5.txt";
            MyStack<int> elem = new MyStack<int>();
            Console.WriteLine(elem.a);
            try
            {
                elem = elem + 1;
                elem--;
                if (elem)
                    Console.WriteLine("не пуст");
                else
                    Console.WriteLine("пуст");

                elem = elem + 2;
                elem = elem + 3;
                elem = elem + 4;
                elem = elem + 5;
                elem--;

                if (elem)
                    Console.WriteLine("не пуст");
                else
                    Console.WriteLine("пуст");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                MyStack<int> elem2 = new MyStack<int>();

                elem2 = elem > elem2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                elem.AddElem(17);
                elem.DelEem();
                elem.LocateElem(4);
                elem.LocateElem(3);
                elem.LocateElem(2);
                elem.LocateElem(1);
                elem.LocateElem(77);
                elem.ReadFile(ADRESS);
                elem.LocateElem(77);
                elem.WriteFile(ADRESS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Все свое отработало");
            }

            try
            {
                Sea sea1 = new Sea("Синие", 20_000, 56, 1_300);
                Sea sea2 = new Sea("Приветов", 200, 23, 13_300);
                Island island1 = new Island("Синие", 13_000, 2, false, sea1);
                Island island2 = new Island("Сокровищь", 31_000, 0, true, sea2);
                Island island3 = new Island("Атракцион", 11_000, -2, true, sea1);

                SchetPlaces<Island> AllIsland = new SchetPlaces<Island>();
                SchetPlaces<Sea> AllSea = new SchetPlaces<Sea>();

                AllIsland._Playces = island1;
                AllIsland._Playces = island2;
                AllIsland._Playces = island3;

                AllSea._Playces = sea1;
                AllSea._Playces = sea2;
                AllSea._Playces = island2.GiveSea();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
