using System;

namespace MyPlace
{
    sealed class Sea : Water, IForGet
    {
        public Sea(string name, int terytory, int flora, int depth): base(terytory, flora)
        {
            Name = name;
            MaxDepth = depth;
        }

        private int maxDepth = 0;

        private int MaxDepth
        {
            set
            {
                if(value>0)
                    maxDepth = value;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Имя моря:{0}",Name);
            Console.WriteLine("Максимальная глубна:{0}", maxDepth);
            base.ShowInfo();
        }

        public override string ToString()
        {
            return "Море\n" + Name;
        }
    }
}
