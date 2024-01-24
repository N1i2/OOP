using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace OurService
{
    class Services : IOrderedDictionary
    {
        public enum worker
        {
            Неуч=-2,
            Новичек,
            Простой,
            Прошаренный,
            Профи
        }

        public Services()
        {
            
        }
        public Services(string newServ, int pepl, double? needTime)
        {
            AddSevice(newServ, pepl, needTime ?? 0);
        }

        Queue<Service> serv=new Queue<Service>();
        List<(string, int)> names = new List<(string, int)>();

        public void AddSevice(string newServ, int pepl, double needTime=0)
        {
            if (names.Contains((newServ, pepl)))
                return;

            Service newS = new Service(newServ, pepl, needTime);

            names.Add((newServ, pepl));
            serv.Enqueue(newS);
        }

        public void DeleteService(string name, int pepl)
        {
            if(!names.Contains((name, pepl)))
                Console.WriteLine("Такой услуги нет");

            names.Remove((name, pepl));

            for(int i=0;i<serv.Count;i++)
            {
                if (serv.ElementAt(i).Name == name && serv.ElementAt(i).Pepl == (worker)pepl)
                    serv.Dequeue();
                else
                serv.Enqueue(serv.Dequeue());
            }
        }

        public Services.Service LocateService(string name, int pepl)
        {
            Service helpS=null;

            for (int i = 0; i < serv.Count; i++)
            {
                if (serv.ElementAt(i).Name == name && serv.ElementAt(i).Pepl == (worker)pepl)
                {
                    helpS = serv.ElementAt(i);
                }
            }

            return helpS;
        }

        public void ShowAll()
        {
            for(int i=0;i<serv.Count;i++)   
                Console.WriteLine($"\nНазвание: {serv.ElementAt(i).Name}\n" +
                    $"Ее выполнитель: {serv.ElementAt(i).Pepl}\n" +
                    $"Время на ее выполнение: {serv.ElementAt(i).needTime}\n" +
                    $"Ее стомость: {(int)serv.ElementAt(i).price}\n".PadRight(60, '='));
        }

        public class Service
        {
            public Service(string newServ, int pepl, double time)
            {
                Name = newServ;
                Pepl = (worker)pepl;
                needTime = GetTrueTime(time);
                price = GetPrice(pepl, time);
            }

            public string Name { get; set; }
            public worker Pepl { get; set; }
            public string needTime { get; }
            public double price { get; }

            private string GetTrueTime(double time)
            {
                if (time == 0)
                    return "Время не известно";

                int hour = (int)time;
                int minut = (int)(Math.Round((time - (double)hour)*100));

                while(minut>=60)
                {
                    hour++;
                    minut-=60;
                }
                while (hour >= 24)
                    hour -= 24;

                return hour + ":" + minut;
            }

            private double GetPrice(int pepl, double time)
            {
                return (time > 0) ? 
                    (double)(((pepl + 3d) * 100d) / time) :
                    (double)((pepl + 3d) * 10d);
            }

            public override string ToString()
            {
                return Name;
            }
        }

        //???????????????????????????????????????????? IOrderedDictionary ?????????????????????????????????????????????????????????
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection Keys => throw new NotImplementedException();

        public ICollection Values => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public void Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object key, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
