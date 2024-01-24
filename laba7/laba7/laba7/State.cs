using System;

namespace MyPlace
{
    sealed partial class State : Land
    {
        struct President
        {
            public string name { get; set; }
            public int age { get; set; }
        }

        public State(string name,int terytory, int location, long popul, Continent cont):base(terytory, location)
        {
            Name = name;
            Popular = popul;
            continent = cont;
            island = null;
        }
        public State(string name, int terytory, int location, long popul, Island island) : base(terytory, location)
        {
            Name = name;
            Popular = popul;
            this.island = island;
            continent = null;
        }

        private ulong? popular = null;
        private Continent continent;
        private Island island;

        public Continent GetContinent
        {
            get => continent;
        }

        public long? Popular
        {
            get
            {
                if (popular == null)
                    throw new Exception("error: Численность населения не была введена");

                return (long)popular;
            }
            set
            {
                if (value <= 0 || value > 8_000_000_000)
                    throw new Exception("error: Такое количество юде невозможно");

                popular = (ulong)value;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Имя государства:{0}", Name);
            Console.WriteLine("Население:{0}", Popular);
            base.ShowInfo();
            if(continent==null)
                island.ShowInfo();
            else
                continent.ShowInfo();

            if (pres.age != 0)
            {
                Console.WriteLine("Призедента завут:{0}", pres.name);
                Console.WriteLine("Его возраст {0} лет", pres.age);
            }
        }

        public override string ToString()
        {
            return "Государство\n" + Name;
        }
    }
}