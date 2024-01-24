using System;

namespace MyDomen
{
    static class WorkWithDomen
    {
        static public void ShowInfoCurrent()
        {
            AppDomain domen = AppDomain.CurrentDomain;

            Console.WriteLine("Имя текущего домена: {0}", domen.FriendlyName);
            Console.WriteLine("\nПодключенные сборки:");

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var asem in domen.GetAssemblies())
                Console.WriteLine(asem.FullName);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static public void ShowInfrNewDomen(string name)
        {
            AppDomain domen = AppDomain.CreateDomain(name);

            Console.WriteLine("\nDo");
            foreach (var item in domen.GetAssemblies())
                Console.WriteLine(item.FullName);

            try
            {
                domen.Load("laba14");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPosle");
            foreach (var item in domen.GetAssemblies())
                Console.WriteLine(item.FullName);

            AppDomain.Unload(domen);

            Console.WriteLine("\nPosle posle");
            foreach (var item in domen.GetAssemblies())
                Console.WriteLine(item.FullName);
        }
    }
}