namespace myHotel
{
    class Admin:IGetRoom
    {
        public Room LocateBestRoom(int count, int aport)
        {
            Room result =new Room();
            int[] priority = new int[RoomPool.rooms.Count];
            int index = -1;
            List<Room> list = new List<Room>();

            foreach (var room in RoomPool.rooms)
            {
                index++;

                if(room.Usebl)
                    continue;

                list.Add(room);

                if(room.MaxPlace>=count)
                    priority[index]+=2;
                if((int)room.AportClass==aport)
                    priority[index]++;
            }

            index = priority.Max();

            if(index == 0)
            {
                Console.WriteLine("Нужной вас комноты не но мы можем предложить альтернативу");
                for (int i = 0;; i++)
                    if (list[i].MaxPlace == list.Max(g=>g.MaxPlace))
                    {
                        priority[i]++;
                        break;
                    }

                index = 1;
            }
            else if(index == 3)
                Console.WriteLine("У нас есть именно то что вы ищете");
            else
                Console.WriteLine("У нас есть следующий вариант");

            for (int i = 0;; i++)
            {
                if (priority[i]==index)
                {
                    index = i;
                    break;
                }
            }

            return RoomPool.rooms[index];
        }
    }
}