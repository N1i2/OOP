using myHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototiptRoom
{
    interface IRoom
    {
        public Room GetClone();
        public void SetProto(Room room);
    }
}
