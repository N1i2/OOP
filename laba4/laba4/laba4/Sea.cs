using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace
{
    sealed class Sea : Name, IForGet
    {
        public Sea(string name, int depth, Water water)
        {
            ObjName = name;
            MaxDepth = depth;
            this.water = water;
        }

        private int? maxDepth = null;
        private Water water;

        public int? MaxDepth
        {
            get
            {
                if (maxDepth == null)
                    throw new Exception("error: Максимальная глубина этого моря неизвестна");

                return maxDepth;
            }
            set
            {
                if (value <= 100 || value > 11_000)
                    throw new Exception("error: Максимальная глубина моря не может быть такой");

                maxDepth = value;
            }
        }

        public Water WaterInfo
        {
            get => water;
        }

        public void ShowInfo()
        {
            Console.WriteLine("\n\nНазвание: море {0}", ObjName);
            Console.WriteLine("Максимальная глубина: {0} м", MaxDepth);
            Console.WriteLine("Море занимает площадь {0} км", water.Teritory);
            Console.WriteLine("Количество фауны в воде: {0}%", water.Flora);
        }

        public override string ToString()
        {
            return "Море\n" + ObjName;
        }
    }
}
