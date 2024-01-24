using myHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrototiptRoom
{
    [Serializable]
    class ProtoRoom : IRoom
    {
        private static string adres = "..\\..\\..\\..\\..\\protoroom.json";
        public Room GetClone()
        {
            Room room;

            using (FileStream file = File.OpenRead(adres))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                room = JsonSerializer.Deserialize<Room>(file, options) ?? new Room();
            }

            return room;
        }

        public void SetProto(Room room)
        {
            using (FileStream file = File.Create(adres))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                JsonSerializer.Serialize(file, room, options);
            }
        }
    }
}
