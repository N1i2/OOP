using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInfo
{
    class NewInfo
    {
        static NewInfo()
        {
            schet = 0;
        }
        public NewInfo(string punkt, string slug, double price)
        {
            schet++;
            Punkt = (punkt != "") ? punkt : "Домой";
            Sluge = (slug != "") ? slug : "Slug №" + schet;
            GetPrice(price);
        }

        static int schet;
        public string Punkt { get; private set; }
        public double Price { get; private set; }
        public string Sluge { get; private set; }
    
        void GetPrice(double price)
        {
            price=(price>0)?price:Math.Abs(price);

            Price=Math.Round(price, 2);
        }
    }
}
