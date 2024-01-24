using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStat
{
    class UnUzeblRoom : Stat
    {
        const bool uze = false;
        public override void ShowUzebl()
        {
            Console.WriteLine("Комната не используеться");
        }

        public override bool Uzebl()
        {
            return uze;
        }
    }
}
