using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DopForQueue
{
    static class QueueDop
    {
        public static void DelElem(this Queue<int> queue, int start, int size=1)
        {
            if (start > queue.Count || start <= 0)
                throw new Exception("Первый символ выходит за рамки очереди");

            size=(size==0)?queue.Count:size;
            bool st = false;

            for (int i = 0, j = 0, end=queue.Count; i < end; i++)
            {
                if (i == start - 1)
                    st = true;
                if (j == size)
                    st = false;

                if (!st)
                {
                    queue.Enqueue(queue.Dequeue());
                    continue;
                }
                
                queue.Dequeue();
                j++;
            }
        }

        public static void vivodDev(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Внесение изменения:");

            if (e.NewItems != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                foreach (var item in e.NewItems)
                    Console.WriteLine("Была добавлена операция {0}", item.ToString());
            }

            if (e.OldItems != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (var item in e.OldItems)
                    Console.WriteLine("Была удолена операция {0}", item.ToString());
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
