using System;
using System.Collections.Generic;
using MyStacks;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyReflektion;
using MyMetod;
using System.Threading;
using System.IO;

namespace laba11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(Reflektion));
            Type[] startType = { typeof(int), typeof(string), typeof(bool), typeof(Type) };
            Type[] types = Assembly.Load(Reflektion.GetAssembleName()).GetTypes();
            List<Type> endTypes = new List<Type>();
            Reflektion.ShowAsemblName();
            Reflektion.ShowPublickConstr();
            Reflektion.ShowPublickMethod();
            Reflektion.ShowPropField();
            Reflektion.ShowInterface();

            try
            {
                int item = 0, tNumb;

                foreach (var type in types)
                {
                    Console.WriteLine($"{++item}) {type.Name}");
                    endTypes.Add(type);
                    if (type.Name.ToString() == "Program")
                        break;
                }

                if (!int.TryParse(Console.ReadLine(), out item) || item <= 0 || item > endTypes.Count)
                    throw new Exception("Это не подходит");

                tNumb = 0;
                foreach (var type in startType)
                    Console.WriteLine($"{++tNumb}) {type}");

                if (!int.TryParse(Console.ReadLine(), out tNumb) || tNumb <= 0 || tNumb > startType.Length)
                    throw new Exception("Это не подходит");

                List<string> need = Reflektion.GetNeedMetod(types[item - 1], startType[tNumb-1]);

                foreach (var type in need)
                {
                    Console.WriteLine(type);
                }

                if(need.Count==0)
                    Console.WriteLine("Таких нет");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Reflektion.WriteFile();

            try
            {
                string[] texts = File.ReadAllLines("../../../../params.txt");
                string helptexts = string.Join("|", texts);
                object[] text = new object[1];
                text[0] = helptexts;

                Reflektion.InvokeFile("laba11.MyClass", "Hello", text);
                text[0] = Reflektion.Generator(typeof(int));
                Reflektion.InvokeFile("laba11.MyClass", "Schet", text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MethodInfo[] metodHelp = (typeof(string).GetMethods());
            string[] names = metodHelp.Select(m => m.Name).Distinct().ToArray();
            foreach (var item in names)
            {
                //Console.Write(item);
                Console.WriteLine(item);   
            }
            Console.WriteLine('\n');

            //lesson 2
            try
            {
                MyClass helpClass = Reflektion.Creat<MyClass>();
                Console.WriteLine(helpClass.five);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
