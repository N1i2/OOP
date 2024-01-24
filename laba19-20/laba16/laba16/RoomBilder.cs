using BilderAport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myHotel;

namespace BilderAport
{
    abstract class RoomBilder
    {
        public Room room { get; private set; }
        public void CreatRoom()
        {
            room = new Room();
        }
        public abstract void SetAge();
        public abstract void SetWifi();
    }
}
