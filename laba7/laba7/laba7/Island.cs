﻿using System;

namespace MyPlace
{
    sealed class Island : Land
    {
        public Island(string name, int teritory, int location, bool live, Sea sea):base(teritory, location)
        {
            Name = name;
            live_in=live;
            this.sea = sea;
        }

        private bool live_in = false;
        private Sea sea;

        public Sea GiveSea()
        {
            return this.sea;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Имя острава: {0}", Name);
            Console.WriteLine("Остров "+ ((live_in)?"густо населен": "не густо населен"));
            base.ShowInfo();
            sea.ShowInfo();
        }

        public override string ToString()
        {
            return "Остров\n" + Name;
        }
    }
}
