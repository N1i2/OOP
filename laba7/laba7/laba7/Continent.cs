using System;

namespace MyPlace
{
    sealed class Continent : Land
    {
        public Continent(string name, int teritory, int location, bool beaf):base(teritory, location)
        {
            Name = name;
            beautiful = beaf;
        }

        private bool beautiful;

        public override void ShowInfo()
        {
            Console.WriteLine("Имя контенента:{0}", Name);
            Console.WriteLine("Контенент "+((beautiful)?"красивый":"не красивый"));
            base.ShowInfo();
        }

        public override string ToString()
        {
            return "Контенент\n" + Name;
        }
    }
}
