namespace myHotel
{
    enum Aportament
    {
        A = 1,
        B,
        C,
        Luxe
    }

    class Room:IGetRoom
    {
        public Room()
        {

        }
        public Room(int count, int aport)
        {
            MaxPlace = count;
            AportClass = (Aportament)aport; 
        }

        public bool Usebl { get; set; } = false;
        public int MaxPlace { get; set; }
        public Aportament AportClass { get; set; }
        public string ClientTime { get; set; } = "";
        public int Place { get; set; }
        public int EndPrice { get; set; }
        public string Name { get; set; } = "";

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
            return 100 * count * (int)AportClass;
        }
        public void RezervRoom(string name, int count, string time, int price)
        {
            Usebl = true;
            Name = name;
            Place = count;
            ClientTime = time;
            EndPrice = price;
        }
    }
}