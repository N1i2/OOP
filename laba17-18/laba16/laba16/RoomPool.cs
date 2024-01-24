using System.Text.Json;
using AbstaractFactory;
using PrototiptRoom;

namespace myHotel
{
    static class RoomPool
    {
        static RoomPool()
        {
            rooms = new List<Room>();
            adres = "..\\..\\..\\..\\..\\rooms.json";
        }

        static public List<Room> rooms { get; private set; }
        static private string adres;

        static public void GetFile()
        {
            Console.WriteLine();

            using (FileStream file = new FileStream(adres, FileMode.Open))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                rooms = JsonSerializer.Deserialize<List<Room>>(file, options) ?? throw new Exception("Файл пуст");
            }
        }
        static public void SetFile(bool need = true)
        {
            Console.WriteLine();

            int count;
            int aport;
            int tipe;
            bool needProto = false;
            ProtoRoom proto = new ProtoRoom();

            if (need)
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Введиет максимальное количество жителей(для завершения введите 0):\t");
                        if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out count) && count >= 0 && count <= 4))
                            throw new Exception("Такого количества не можеть быть");
                        Console.WriteLine();

                        if (count == 0)
                            break;

                        Console.Write("Введиет тип дома\n(1,2 старый дом с/или без wifi; 3,4 новы дом с/млм без wifi):\t");
                        if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out tipe) && tipe >= 1 && tipe <= 4))
                            throw new Exception("Такого типа нет");
                        Console.WriteLine();

                        Console.Write("Введиет класс апортамента\n(1-4: Дома класов A, B, C, Luxe; 5-8: Квартиры классов A, B, C, Luxe):\t");
                        if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out aport) && aport >= 1 && aport <= 8))
                            throw new Exception("Такого класса нет");
                        Console.WriteLine();

                        AportamentFactory aportam = new FlatLuxe();
                        if (aport == 1)
                            aportam = new HousA();
                        else if (aport == 2)
                            aportam = new HousB();
                        else if (aport == 3)
                            aportam = new HousC();
                        else if (aport == 4)
                            aportam = new HousLuxe();
                        else if (aport == 5)
                            aportam = new FlatA();
                        else if (aport == 6)
                            aportam = new FlatB();
                        else if(aport == 7)
                            aportam = new FlatC();

                        rooms.Add(Room.CreatRoom(count, tipe, aportam));

                        if (!needProto)
                        {
                            Console.Write("Что бы сделать копию прототипа последнего ввода нажмите (0): ");
                            if (int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out aport) && aport == 0)
                            {
                                needProto = true;
                                proto.SetProto(rooms[rooms.Count - 1]);
                            }
                            Console.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                if (needProto)
                {
                    Console.Write("Что бы вставить копию прототипа нажмите (0): ");
                    if (int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out aport) && aport == 0)
                        rooms.Add(proto.GetClone());
                    Console.WriteLine();
                }

                Console.Write("Пересохранить колекцию в файл?(нажмите 1)");
                if (!int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out count) || count != 1)
                    return;
            }

            Console.WriteLine();
            using (FileStream file = new FileStream(adres, FileMode.Create))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                JsonSerializer.Serialize(file, rooms, options);
            }
        }
    }
}