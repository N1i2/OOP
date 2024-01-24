using genericsWork;
using System;
using System.Collections;
using System.IO;

namespace MyStacks
{
    class MyStack<T>:IMetod<T>, IEnumerable, IEnumerator where T : struct 
                                                            //where U : class
    {
        public T a = default(T);
        public void ReadFile(string adress)
        {
            if (!File.Exists(adress))
                throw new Exception("Файл не обнаружен");

            object[] value= File.ReadAllLines(adress);
            T res;

            for (int i = 0; i < value.Length; i++)
            {
                if (Convert.ToString(value[i]) == "" || Convert.ToString(value[i])==" ")
                    continue;

                res = (T)Convert.ChangeType(value[i], typeof(T));

                AddEl(res);
                size++;
            }
        }

        public void WriteFile(string adress)
        {
            if (!File.Exists(adress))
                File.Create(adress);

            ElemStack<T> elem = start;
            File.WriteAllText(adress, "");

            while(elem!=null)
            {
                File.AppendAllText(adress,Convert.ToString(elem.element+"\n"));
                elem = elem.next;
            }
        }

        private class ElemStack<S>
        {
            public ElemStack(S elem)
            {
                element = elem;
                next = null;
            }

            public ElemStack<S> next { get; set; }
            public S element { get; set; }
        }

        public int size { get; private set; }

        public object Current => throw new NotImplementedException();

        public MyStack()
        {
            start = null;
        }

        private ElemStack<T> start;

        private void AddEl(T elem)
        {
            ElemStack<T> newElem = new ElemStack<T>(elem);

            newElem.next = start;
            start = newElem;

        }

        public void AddElem(T element)
        {
            ElemStack<T> elem= new ElemStack<T>(element);
            elem.next = start;
            size++;
            start = elem;
        }

        public void DelEem()
        {
            if (size <= 0)
                throw new Exception("Стек и так пуст");
            start = start.next;
            size--;
        }

        public void LocateElem(T elements)
        {
            ElemStack<T> elem = start;

            while (elem != null)
            {
                if (elem.element.Equals(elements))
                    break;
                elem = elem.next;
            }

            if(elem==null)
                Console.WriteLine("Эимента {0} нет", elements);
            else
                Console.WriteLine("Элемент {0} есть", elements);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public static MyStack<T> operator +(MyStack<T> steck, T elem)
        {
            steck.AddEl(elem);
            steck.size++;

            return steck;
        }
        public static MyStack<T> operator --(MyStack<T> steck)
        {
            if (steck.size <= 0)
                throw new Exception("Удолять нечего");

            steck.start = steck.start.next;
            steck.size--;

            return steck;
        }
        public static bool operator true(MyStack<T> steck)
        {
            return (steck.size == 0) ? false : true;
        }
        public static bool operator false(MyStack<T> steck)
        {
            return false;
        }
        public static MyStack<T> operator >(MyStack<T> steck1, MyStack<T> steck2)
        {
            if (steck1.size == 0)
                throw new Exception("Нечего копировать");
            T[] arr = new T[steck1.size];
            ElemStack<T> helpElem = steck1.start;

            for (int i = 0; helpElem != null; i++)
            {
                arr[i] = helpElem.element;
                helpElem = helpElem.next;
            }

            Array.Sort(arr);

            for (int i = arr.Length - 1; i >= 0; i--)
                steck2 = steck2 + arr[i];

            return steck2;
        }
        public static MyStack<T> operator <(MyStack<T> steck1, MyStack<T> steck2)
        {
            return steck1;
        }
    }
}
