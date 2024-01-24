using myHotel;
using MyProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba16
{
    class ProxyWorker : IProxy
    {
        public bool ShowThisRoom(Room room, int price)
        {
            Console.WriteLine($"Комната на {room.MaxPlace} мест");
            Console.WriteLine($"Класс апортамента {room.Aport}");
            Console.WriteLine($"Строимость под ваши запросы {price}");
            Console.WriteLine($"Апортамент {room.HousFlat} {room.oldYeang.Name}");
            Console.WriteLine($"Эти апортаменты " + ((room.wifi == null) ? "без" : "с") + " WiFi");

            Console.Write("Если вы согласы то нажмите 1:\t");
            if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out int app) && app == 1))
                return false;
            return true;
        }
    }
}
