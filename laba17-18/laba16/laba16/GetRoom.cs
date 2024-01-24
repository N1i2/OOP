using myHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myHotel
{
    abstract class GetRoom
    {
        static public void ShowNotUzibl()
        {
            int index = 0;
            foreach (var room in RoomPool.rooms)
            {
                if (room.Usebl)
                    continue;

                if(index%2==0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine($"Комната №{++index}");
                Console.WriteLine($"В ней могут жить {room.MaxPlace} человек");
                Console.WriteLine($"Эти апортоменты класса {room.Aport}");
                Console.WriteLine($"По виду это {room.HousFlat}");
                Console.WriteLine($"По типу апортамент {room.oldYeang.Name}");
                Console.Write((room.wifi != null)?"C ":"Без ");
                Console.WriteLine("WiFi");

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static public void ShowAllRoom()
        {
            int index = 0;
            foreach (var room in RoomPool.rooms)
            {
                if (index % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine($"Комната №{++index}");
                Console.WriteLine($"В ней могут жить {room.MaxPlace} человек");
                Console.WriteLine($"Эти апортоменты класса {room.Aport}");
                Console.WriteLine($"По виду это {room.HousFlat}");
                Console.WriteLine($"По типу апортамент {room.oldYeang.Name}");
                Console.Write((room.wifi != null) ? "C " : "Без ");
                Console.WriteLine("WiFi");
                if (room.Usebl)
                {
                    Console.WriteLine($"В данный момент комноту забронировало {room.Name}");
                    Console.WriteLine($"Забронированно на {room.Place} человек");
                }
                else
                    Console.WriteLine("В данный момент не занет");

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
