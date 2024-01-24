using myHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myHotel
{
    public interface IGetRoom
    {
        static public void ShowNotUzibl()
        {
            int index = 0;
            foreach (var room in RoomPool.rooms)
            {
                if (room.Usebl)
                    continue;

                Console.WriteLine($"Комната №{++index}");
                Console.WriteLine($"В ней могут жить {room.MaxPlace} человек");
                Console.WriteLine($"Эти апортоменты класса {room.AportClass}");
            }
        }
        public void ShowAllRoom()
        {
            int index = 0;
            foreach (var room in RoomPool.rooms)
            {
                Console.WriteLine($"Комната №{++index}");
                Console.WriteLine($"В ней могут жить {room.MaxPlace} человек");
                Console.WriteLine($"Эти апортоменты класса {room.AportClass}");
                if (room.Usebl)
                {
                    Console.WriteLine($"В данный момент комноту забронировало {room.Name}");
                    Console.WriteLine($"Забронированно на {room.Place} человек");
                }
                else
                    Console.WriteLine("В данный момент не занет");
            }
        }
    }
}
