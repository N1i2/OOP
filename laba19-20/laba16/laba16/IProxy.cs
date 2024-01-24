using myHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProxy
{
    interface IProxy
    {
        public bool ShowThisRoom(Room room, int price);
    }
}
