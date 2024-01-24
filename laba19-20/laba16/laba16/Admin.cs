using MyProxy;
using MyTempl;

namespace myHotel
{
    class Admin : GetRoom, IProxy
    {
        private Admin()
        {

        }

        static private Admin admin = null;

        static public Admin GetAdmin()
        {
            if (admin == null)
                admin = new Admin();

            return admin;
        }

        public void SayGoodBy(TemplAbstr temp)
        {
            temp.ShowOurSay();
        }

        public Room LocateBestRoom(int count, string aport)
        {
            Room result = new Room();
            int[] priority = new int[RoomPool.rooms.Count];
            int index = -1;
            List<Room> list = new List<Room>();

            foreach (var room in RoomPool.rooms)
            {
                index++;

                if (room.Uzebl.Uzebl())
                    continue;

                list.Add(room);

                if (room.MaxPlace >= count)
                    priority[index] += 2;
                if (room.Aport == aport)
                    priority[index]++;
            }

            index = priority.Max();

            if (index == 0)
            {
                Console.WriteLine("Нужной для вас комноты нет, но мы можем предложить альтернативу");
                for (int i = 0; ; i++)
                    if (list[i].MaxPlace == list.Max(g => g.MaxPlace))
                    {
                        priority[i]++;
                        break;
                    }

                index = 1;
            }
            else if (index == 3)
                Console.WriteLine("У нас есть именно то что вы ищете");
            else
                Console.WriteLine("У нас есть следующий вариант");

            for (int i = 0; ; i++)
            {
                if (priority[i] == index)
                {
                    index = i;
                    break;
                }
            }

            return RoomPool.rooms[index];
        }

        public bool ShowThisRoom(Room room, int price)
        {

            Console.WriteLine($"Комната на {room.MaxPlace} мест");
            Console.WriteLine($"Класс апортамента {room.Aport}");
            Console.WriteLine($"Строимость под ваши запросы {price}");

            Console.Write("Если вы согласы то нажмите 1:\t");
            if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out int app) && app == 1))
            {
                Console.WriteLine("\nУспешно отказано");
                return false;
            }

            return true;
        }
    }
}