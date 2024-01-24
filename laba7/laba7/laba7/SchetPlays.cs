using System;
using System.Collections.Generic;

namespace MyPlace
{
    class SchetPlaces<T>where T : Place
    {
        public SchetPlaces()
        {
            places = new List<T>();            
        }

        private List<T> places;

		public T _Playces
        {
            get
            {
                foreach (Place p in places)
                {
                    Console.WriteLine(p.ToString());
                }
                return places[0];
            }
            set
            {
                places.Add(value);
            }
        }
    }
}
