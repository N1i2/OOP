using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace MyPlace
{
    [Serializable]    
    public class Sea : Name, IForGet, ISerializable
    {
        public Sea()
        {

        }
        public Sea(string name, int depth, Water water)
        {
            ObjName = name;
            MaxDepth = depth;
            this.water = water;
        }

        [NonSerialized]
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(Sea));
            info.AddValue("Name", ObjName);
            info.AddValue("Depth", (int)maxDepth);
        }

        private Sea(SerializationInfo info, StreamingContext ctx)
        {
            ObjName = info.GetString("Name");
            maxDepth = info.GetInt32("Depth");
        }
    }
}
