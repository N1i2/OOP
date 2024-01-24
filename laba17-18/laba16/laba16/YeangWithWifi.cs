using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilderAport
{
    class YeangWithWifi : RoomBilder
    {
        public override void SetAge()
        {
            this.room.oldYeang = new OldOrYeang { Name = "новый" };
        }

        public override void SetWifi()
        {
            this.room.wifi = new WiFi();
        }
    }
}
