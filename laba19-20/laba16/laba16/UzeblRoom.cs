using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStat
{
    class UzeblRoom : Stat
    {
        const bool uze = true;
        public override void ShowUzebl()
        {
            Console.WriteLine("Комнота используеться");
        }

        public override bool Uzebl()
        {
            return uze;
        }
    }
}
