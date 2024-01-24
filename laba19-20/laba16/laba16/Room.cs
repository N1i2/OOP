﻿using AbstaractFactory;
using BilderAport;
using MyStat;

namespace myHotel
{
    [Serializable]
    class Room:GetRoom
    {
        public Room()
        {

        }
        public static Room CreatRoom(int count, int tipe, AportamentFactory aport)
        {
            RoomBilder bild;
            Bilder bilder = new Bilder();

            if (tipe == 1)
                bild = new OldWithWifi();
            else if (tipe == 2)
                bild = new OldWithoutWifi();
            else if (tipe == 3)
                bild = new YeangWithWifi();
            else
                bild = new YeangWithoutWifi();

            Room newRoom = new Room();

            newRoom = bilder.Bild(bild);

            newRoom.MaxPlace = count;
            newRoom.Aport = aport.GetAportClass().Aport();
            newRoom.HousFlat = aport.GetVid().VidFlat();

            newRoom.Uzebl = new UnUzeblRoom();
            newRoom.uze = false;
            
            return newRoom;
        }

        public bool uze { get; set; }
        public Stat Uzebl { get; set; } 
        public int MaxPlace { get; set; }
        public string Aport { get; set; } = "";
        public string HousFlat { get; set; } = "";
        public string ClientTime { get; set; } = "";
        public int Place { get; set; }
        public int EndPrice { get; set; }
        public string Name { get; set; } = "";
        public OldOrYeang oldYeang { get; set; }
        public WiFi wifi { get; set; }

        static public string GetTime(string time)
        {
            string[] allMonth = { "января ", "февраля ", "марта ", 
                               "апреля ", "мая ", "июня ",
                               "июля ", "августа ", "сентября ",
                               "октября ", "ноября ", "декабря "};
            int[] days = { 31, 28, 31, 30, 31, 30, 30, 31, 30, 31, 30, 31 };

            string[] numb = time.Split('-');
            int month;
            int day;

            if (numb.Length != 2)
                throw new Exception("Дата задана неправильно");

            month = int.Parse(numb[0])-1;
            day = int.Parse(numb[1]);

            if(month<0||month>11|| day < 1 || day > days[month])
                throw new Exception("Дата задана неправильно");

            return Convert.ToString(day)+allMonth[month];
        }
        public int GetPrice(int count)
        {
            int mnog;
            if (Aport == "A")
                mnog = 1;
            else if (Aport == "B")
                mnog = 2;
            else if (Aport == "C")
                mnog = 3;
            else
                mnog = 4;

            return 100 * count * mnog;
        }
        public void RezervRoom(string name, int count, string time, int price)
        {
            Uzebl = new UzeblRoom();
            uze = true;
            Name = name;
            Place = count;
            ClientTime = time;
            EndPrice = price;
        }
    }
}