using System;
using System.Text;

namespace Worcks
{
    class MyString
    {
        public static void Modul()
        {
            //работа со строками
            string hello = "hello world";
            string howWorlde = "how are you";
            string byby = "goodbye see you later";

            if (hello == howWorlde)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

            Console.WriteLine(hello.CompareTo(howWorlde));
            Console.WriteLine(howWorlde.CompareTo(howWorlde));
            Console.WriteLine(howWorlde.CompareTo(hello));

            //конкотенация
            string greetings = hello + ' ' + howWorlde;
            Console.WriteLine(greetings);
            //копия
            string by = string.Copy(byby);
            Console.WriteLine(by);
            //ввыделение подстройки
            Console.WriteLine(howWorlde.Substring(4, 3));
            //разделение на слова
            string[] worlds = greetings.Split(new char[] { ' ' });

            foreach (string item in worlds)
            {
                Console.WriteLine(item);
            }
            //встака спереди
            byby.Insert(0, "_");
            byby.Insert(byby.Length, " world");
            Console.WriteLine(byby);
            //yдоление
            byby = byby.Remove(13);
            Console.WriteLine(byby);
            Console.WriteLine();
            //пустая и нулевая страка
            string emptyString = string.Empty;
            string nullString = null;

            if (emptyString == nullString)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

            Console.WriteLine(string.IsNullOrEmpty(emptyString));
            Console.WriteLine(string.IsNullOrEmpty(nullString));
            Console.WriteLine(string.IsNullOrEmpty(hello));

            string name = nullString ?? "Николай";
            Console.WriteLine(name);
            //StringBuilder 
            StringBuilder sb = new StringBuilder("hello world", 32);
            Console.WriteLine();
            Console.WriteLine(sb);
            Console.WriteLine(sb.Remove(4, 3));
            Console.WriteLine(sb.Insert(0, 'k'));
            Console.WriteLine(sb.Insert(sb.Length, 's'));
        }
    }
}