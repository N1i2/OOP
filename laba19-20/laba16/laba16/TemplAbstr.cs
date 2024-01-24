using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTempl
{
    abstract class TemplAbstr
    {
        public void ShowOurSay()
        {
            this.SayAboutUs();
            this.SayAboutResulr();
        }

        protected void SayAboutUs()
        {
            Console.WriteLine("Вы воспользовались службой HELLoWorLDD");
        }
        protected abstract void SayAboutResulr();
    }
}
