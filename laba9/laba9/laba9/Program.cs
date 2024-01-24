using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using OurService;
using DopForQueue;
using System.Linq;

namespace laba9
{
    class Program
    {
        static void Main(string[] args)
        {
            Services service = new Services("Доставка", -1, 4.32);
            service.AddSevice("Специальный заказ", 1);
            service.AddSevice("Оптовый заказ", 2, 30.95);
            service.AddSevice("Специальный заказ", 1);

            service.ShowAll();

            service.DeleteService("Доставка", -1);
            service.DeleteService("доставка", -1);

            Services.Service help = service.LocateService("Оптовый заказ", 2);

            if (help != null)
                Console.WriteLine($"Название: {help.Name}\n" +
                    $"Затраченое время: {help.needTime}\n" +
                    $"Стоимость: {(int)help.price}$\n");
            else
                Console.WriteLine("Такого нет");

            //lesson 2
            Queue<int> helpQu = new Queue<int>();
            helpQu.Enqueue(1);
            helpQu.Enqueue(2);
            helpQu.Enqueue(3);
            helpQu.Enqueue(4);
            helpQu.Enqueue(5);

            while (helpQu.Count != 0)
                Console.WriteLine(helpQu.Dequeue());

            Console.WriteLine("=".PadRight(60, '='));

            helpQu.Enqueue(1);
            helpQu.Enqueue(2);
            helpQu.Enqueue(3);
            helpQu.Enqueue(4);
            helpQu.Enqueue(5);
            helpQu.Enqueue(6);
            helpQu.Enqueue(7);
            helpQu.Enqueue(8);
            helpQu.Enqueue(9);
            helpQu.Enqueue(10);

            try
            {
                helpQu.DelElem(2,5);

                while (helpQu.Count != 0)
                    Console.WriteLine(helpQu.Dequeue());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

            helpQu.Enqueue(4);
            helpQu.Enqueue(5);
            helpQu.Enqueue(6);
            helpQu.Enqueue(7);

            List<int> hi = new List<int>() { 1, 2, 3};

            while (helpQu.Count != 0)
                hi.Add(helpQu.Dequeue());

            try
            {
                Console.WriteLine("\nВывод списка");
                foreach (int index in hi)
                    Console.WriteLine(index);

                Console.WriteLine("Введите любое число");
                int numb;

                if (!int.TryParse(Console.ReadLine(), out numb))
                    throw new Exception("Это не чило");

                if (!hi.Contains(numb))
                    Console.WriteLine("Такого числа нет");
                else
                    Console.WriteLine("Такое число есть");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ObservableCollection<Services.Service> thredLes = new ObservableCollection<Services.Service>();
            thredLes.CollectionChanged += QueueDop.vivodDev;

            thredLes.Add(new Services.Service("Доставка", -1, 4.32));
            thredLes.Add(new Services.Service("Специальный заказ", 1, 90));
            thredLes.Add(new Services.Service("Оптовый заказ", 2, 30.95));

            thredLes.Remove(thredLes[1]);
        }
    }
}
