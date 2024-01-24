using laba16;
using MyDirorator;
using MyTempl;
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

        public void ShowMyRoom(Dicorate dicor)
        {
            Console.Write($"Покупатель {name } : ");
            dicor.ShowMyRoom();
        }

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
                    
                    ProxyWorker prox = new ProxyWorker();

                    if (!prox.ShowThisRoom(prim, price))
                    {
                        Console.WriteLine();
                        admin.SayGoodBy(new NotChoiUs());
                        break;
                    }
                    Console.WriteLine();
                    admin.SayGoodBy(new ChoiUs());

                    prim.RezervRoom(name, count, time, price);
                    MyRezerv = prim;
        
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