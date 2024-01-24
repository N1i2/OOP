using System;
using System.Text.Json;

namespace myHotel
{
    class Client:GetRoom
    {
        static Client()
        {
            adres = "..\\..\\..\\..\\..\\clients.json";
        }
        static public void ShowNotUzibl()
        {
            throw new Exception("Для просмотра всей инфы у вас недостаточно прав");
        }

        public Client(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
        public Room MyRezerv { get; set; } = new Room();
        static private string adres;

        public void GetBooked(Admin admin)
        {
            int count;
            string aport;
            string time;
           
            while (true)
            {
                try
                {
                    Console.Write("Введите количество сожителей(не больше 4):");
                    if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out count) && count >= 0 && count <= 4))
                        throw new Exception("Неверное количество сожиетлей");
                    Console.WriteLine();

                    Console.Write("Введите класс апартамента(A, B, C, Luxe):");
                    aport = Console.ReadLine()??"A";
                    if(aport!="A"&& aport != "B"&& aport != "C"&& aport != "Luxe")
                        throw new Exception("Такого класса нет");

                    Console.WriteLine("Введите дату заезда(только на текущий год вперед MM-DD)");
                    time = Console.ReadLine()??"";

                    time = Room.GetTime(time);

                    Room prim = admin.LocateBestRoom(count, aport);

                    int price = prim.GetPrice(count);

                    Console.WriteLine($"Комната на {prim.MaxPlace} мест");
                    Console.WriteLine($"Класс апортамента {prim.Aport}");
                    Console.WriteLine($"Строимость под ваши запросы {price}");
                    Console.WriteLine($"Апортамент {prim.HousFlat} {prim.oldYeang.Name}");
                    Console.WriteLine($"Эти апортаменты " + ((prim.wifi == null)?"без":"с") + " WiFi");

                    Console.Write("Если вы согласы то нажмите 1:\t");
                    if (!(int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out int app) && app == 1))
                    {
                        Console.WriteLine("\nУспешно отказано");
                        return;
                    }

                    prim.RezervRoom(name, count, time, price);
                    MyRezerv = prim;
                    Console.WriteLine("\nУспешно подтверждено");
        
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        static public void SetFile(List<Client> clients)
        {
            using (FileStream file = new FileStream(adres, FileMode.Create))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                JsonSerializer.Serialize(file, clients, options);
            }
        }
    }
}