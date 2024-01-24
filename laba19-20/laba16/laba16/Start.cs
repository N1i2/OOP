using MyDirorator;
using myHotel;
using MyCommand;

namespace Program
{
    static class Start
    {
        static void Main()
        {
            int chus;

            Console.WriteLine("Хотите использовать существующий набор комнат нажмите 1");
            if (int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out chus) && chus == 1)
                RoomPool.GetFile();
            else
                RoomPool.SetFile();

            string name;

            Admin admin = Admin.GetAdmin();
            Admin admin2 = Admin.GetAdmin();

            int index = 0;

            List<Client> clients= new List<Client>();
            Invoke invok = new Invoke();

            while (true)
            {
                try
                {
                    Console.Write("Введите имя(введите end что бы закончить):");
                    name = Console.ReadLine() ?? "";
                    if (name.Replace(" ", "") == "")
                        name = "Иван №" + (++index);

                    if (name == "end")
                        break;

                    if (clients.Any(h => h.name == name))
                        throw new Exception("Такое имя уже есть");

                    Client client = new Client(name);

                    client.GetBooked(admin);

                    client.ShowMyRoom(new ConcretDicorate());

                    invok.SetCommand(new ProgectCommand(name));
                    clients.Add(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                Admin.ShowAllRoom();

                RoomPool.SetFile(false);
                Client.SetFile(clients);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            invok.ShowAllNames();
            Console.WriteLine();


            Console.WriteLine("Конец");
        }
    }
}