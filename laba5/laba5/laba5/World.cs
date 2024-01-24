using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    class World : AbstrMetod
    {
        private List<Place> places = new List<Place>();
        private List<char> typeObj = new List<char>();

        public List<Place> GivePlace
        {
            get => places;
        }

        public List<char> TypeObj
        {
            get => typeObj;
        }

        public override object GetObj
        {
            set
            {
                AddNewObj(value);
            }
        }

        protected override void AddNewObj(object obj)
        {
            if (obj is Place place)
            {
                places.Add(place);

                if (place is Sea)
                    typeObj.Add('s');
                else if (place is Continent)
                    typeObj.Add('c');
                else if (place is Island)
                    typeObj.Add('i');
                else
                    typeObj.Add('t');
            }
        }

        public override void DeleteObj(string name, char type = 'a')
        {
            for (int i = 0; i < places.Count; i++)
            {
                if (name == places[i].Name)
                {
                    if (typeObj[i] == type || type == 'a')
                    {
                        places.RemoveAt(i);
                        typeObj.RemoveAt(i);
                        return;
                    }
                }
            }

            Console.WriteLine("Такого элемента нет");
        }

        public override void ShowAllObj()
        {
            for (int i = 0; i < places.Count; i++)
            {
                if (typeObj[i] == 's')
                    Console.Write("Море ");
                else if (typeObj[i] == 'c')
                    Console.Write("Контенент ");
                else if (typeObj[i] == 'i')
                    Console.Write("Остров ");
                else
                    Console.Write("Государство ");

                Console.WriteLine(places[i].Name);
            }
        }
    }
}
