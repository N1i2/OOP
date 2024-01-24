using MyPlace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    class Kontrol
    {
        private World worlds;
        public Kontrol(World world)
        {
            worlds = world;
        }

        public int LocateStates(string name)
        {
            int col = 0;

            for (int i = 0; i < worlds.GivePlace.Count; i++)
                if (worlds.TypeObj[i] == 't')
                {
                    State s = worlds.GivePlace[i] as State;
                    if (s.GetContinent != null && s.GetContinent.Name == name)
                        col++;
                }

            return col;
        }

        public int ColSea()
        {
            int col = 0;

            for (int i = 0; i < worlds.GivePlace.Count; i++)
                if (worlds.TypeObj[i] == 's')
                    col++;

            return col;
        }

        public void IslandOrder()
        {
            List<string> iName = new List<string>();

            for (int i = 0; i < worlds.GivePlace.Count; i++)
                if (worlds.TypeObj[i] == 'i')
                    iName.Add(worlds.GivePlace[i].Name);

            iName.Sort();

            for (int i = 0; i < iName.Count; i++)
                Console.WriteLine(iName[i]);

            iName.Clear();
        }
    }
}
