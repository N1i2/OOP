using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myHotel;

namespace BilderAport
{
    class Bilder
    {
        public Room Bild(RoomBilder bild)
        {
            bild.CreatRoom();
            bild.SetAge();
            bild.SetWifi();
            return bild.room;
        }
    }
}
