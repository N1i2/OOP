using System.Text.Json;

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

                        Console.Write("Введиет класс апортамента:\t");
                        if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out aport) && aport >= 1 && aport <= 4))
                            throw new Exception("Такого класса нет");
                        Console.WriteLine();

                        rooms.Add(new Room(count, aport));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
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