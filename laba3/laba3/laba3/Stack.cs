using System;
using MyDevoloper;

namespace MyStacks
{
    class MyStack<T>
    {
        private T[] _steck;
        private T[] help;
        private int index { get; set; } = 0;
        private static T[] _delStack;
        private static int delIndex;

        public int Index
        {
            get { return index; }
        }
        public T _Steck
        {
            set
            {
                help = new T[index];

                for (int i = 0; i < index; i++)
                    help[i] = _steck[i];

                _steck = new T[++index];


                _steck[0] = value;
                for (int i = 0; i < index - 1; i++)
                    _steck[i + 1] = help[i];

                help = null;
            }
        }
        public T getSteck(int index)
        {
            return _steck[index];
        }

        static MyStack()
        {
            delIndex = 0;
            _delStack = new T[delIndex];
        }

        public MyStack()
        {

        }

        public MyStack(T obj)
        {
            _steck = new T[++index];
            _steck[0] = obj;
        }

        public static MyStack<T> operator +(MyStack<T> myStack, T obj)
        {
            myStack._Steck = obj;
            return myStack;
        }

        public static MyStack<T> operator ++(MyStack<T> mySteck)
        {
            return mySteck;
        }

        private static void CreatDelStack(T obj)
        {
            T[] help = new T[++delIndex];

            for (int i = 0; i < delIndex - 1; i++)
                help[i] = _delStack[i];

            help[delIndex - 1] = obj;

            _delStack = new T[delIndex];

            for (int i = 0; i < delIndex; i++)
                _delStack[i] = help[i];
        }

        internal void peple(string v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }

        public static MyStack<T> operator --(MyStack<T> mySteck)
        {
            if (mySteck.index == 0)
                return mySteck;
            if (mySteck.index == 1)
            {
                CreatDelStack(mySteck._steck[0]);

                mySteck._steck = new T[0];
                mySteck.index = 0;
                return mySteck;
            }
            CreatDelStack(mySteck._steck[0]);

            mySteck.help = new T[--(mySteck.index)];
            for (int i = 0; i < mySteck.index; i++)
                mySteck.help[i] = mySteck._steck[i + 1];

            mySteck._steck = new T[mySteck.index];
            for (int i = 0; i < mySteck.index; i++)
                mySteck._steck[i] = mySteck.help[i];

            return mySteck;
        }

        public static bool operator true(MyStack<T> myStack)
        {
            if (myStack.index == 0)
                return false;
            return true;
        }

        public static bool operator false(MyStack<T> myStack)
        {
            return true;
        }

        public static MyStack<T> operator >(MyStack<T> first, MyStack<T> second)
        {
            if (second)
            {
                first.index = second.index;
                first._steck = new T[first.index];

                for (int i = 0; i < first.index; i++)
                    first._steck[i] = second._steck[i];

                Array.Sort(first._steck);
            }

            return first;
        }

        public static MyStack<T> operator <(MyStack<T> first, MyStack<T> second)
        {
            return first;
        }

        public T this[int index]
        {
            get => _steck[index];
            set => _steck[index] = value;
        }
        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh ВЛОЖЕННЫЙ ОБЬЕКТ hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        public Devoloper peple2;
        
        public void Geter(string name, int otdel)
        {
            peple2 = new Devoloper(name, otdel);
        }
        //hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh
        public static class StaticOpereshen
        {
            public static int ShowCol()
            {
                return delIndex;
            }

            public static int SumDelElement()
            {
                int result = 0;
                for (int i = 0; i < delIndex; i++)
                {
                    result += Convert.ToInt32(_delStack[i]);
                }

                return result;
            }

            public static int FmaxTnim()
            {
                int max = int.MinValue;
                int min = int.MaxValue;

                for (int i = 0; i < delIndex; i++)
                {
                    if (Convert.ToInt32(_delStack[i]) > max)
                        max = Convert.ToInt32(_delStack[i]);
                    if (Convert.ToInt32(_delStack[i]) < min)
                        min = Convert.ToInt32(_delStack[i]);
                }

                return max - min;
            }
        }
    }
}
