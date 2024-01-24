using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilderAport
{
    class OldWithoutWifi:RoomBilder
    {
        public override void SetAge()
        {
            this.room.oldYeang = new OldOrYeang { Name = "старый" };
        }

        public override void SetWifi()
        {}
    }
}
