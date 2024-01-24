using laba11;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MyReflektion
{
    static class Reflektion
    {
        static Reflektion()
        {
            asembInfo = Assembly.GetExecutingAssembly();
            constrInfo = (typeof(MyClass).GetConstructors());
            metodInfo = (typeof(MyClass).GetMethods(BindingFlags.Public | BindingFlags.Instance));
            propInfo = (typeof(MyClass).GetProperties(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Instance));
            fieldInfo = (typeof(MyClass).GetFields(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Instance));
            interfInfo = (typeof(MyClass).GetInterfaces());
        }

        static private Assembly asembInfo;
        static private ConstructorInfo[] constrInfo;
        static private MethodInfo[] metodInfo;
        static private PropertyInfo[] propInfo;
        static private FieldInfo[] fieldInfo;
        static private Type[] interfInfo;

        static public void ShowAsemblName()
        {
            Console.WriteLine("Класс в сборке: {0}", GetAssembleName());
        }
        static public void ShowPublickConstr()
        {
            if (GetPublicConstr())
                Console.WriteLine("Публичные конструкторы есть");
            else
                Console.WriteLine("Пуличных конструкторов нет");
        }
        static public void ShowPublickMethod()
        {
            IEnumerable<string> names = GetPublicMetod();

            Console.ForegroundColor = ConsoleColor.Red;
            Show(names);

            if (names.Count() != 0)
                return;

            Console.WriteLine("В классе нет публичных методов");
        }
        static public void ShowPropField()
        {
            IEnumerable<string> names =GetPropField();

            Console.ForegroundColor = ConsoleColor.Blue;
            Show(names);

            if (names.Count() != 0)
                return;

            Console.WriteLine("В классе нет полей и свойств");
        }
        static public void ShowInterface()
        {
            IEnumerable<string> names = GetInterface();

            Console.ForegroundColor = ConsoleColor.Green;
            Show(names);

            if (names.Count() != 0)
                return;

            Console.WriteLine("Класс не реализует интерфейсы");
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%% ВЫВОД %%%%%%%%%%%%%%%%%%%%%%%%%%%
        static private void Show(IEnumerable<string> names)
        {
            foreach (string name in names)
                Console.WriteLine(name);

            Console.ForegroundColor = ConsoleColor.White;
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%% ПЕРЕДАЧА %%%%%%%%%%%%%%%%%%%%%%%%%%%
        static public string GetAssembleName()
        {
            return asembInfo.GetName().Name;
        }

        static public bool GetPublicConstr()
        {
            return constrInfo.Any(constr => constr.IsPublic);
        }
        static public IEnumerable<string> GetPublicMetod()
        {
            return metodInfo.Select(met => met.Name);
        }
        static public IEnumerable<string> GetPropField()
        {
            return propInfo.Select(met => met.Name).Concat(fieldInfo.Select(fie => fie.Name));
        }
        static public IEnumerable<string> GetInterface()
        {
            return interfInfo.Select(met => met.Name);
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%% ФАЙЛ %%%%%%%%%%%%%%%%%%%%%%%%%%%
        static public void WriteFile()
        {
            string name=GetAssembleName();
            bool constr=GetPublicConstr();
            IEnumerable<string> metod = GetPublicMetod();
            IEnumerable<string> propField = GetPropField();
            IEnumerable<string> interf = GetInterface();

            using (StreamWriter write =new StreamWriter("../../../../InformClass.txt"))
            {
                write.WriteLine($"\n=======Протокол за {DateTime.Now}=======\n");
                write.WriteLine($"Класс находится в сборке: {name}");
                write.WriteLine((constr)?"У класса есть открытые конструкторы":"У класса нет открытых конструкторов");
                write.WriteLine("\nВСЕ ОТКРЫТЫЕ МЕТОДЫ");
                foreach (var met in metod)
                    write.WriteLine($"{met}");
                if(metod.Count()==0)
                    write.WriteLine("Таких нет");

                write.WriteLine("\nВСЕ СВОЙСТВА И ПОЛЯ");
                foreach (var pAf in propField)
                    write.WriteLine($"{pAf}");
                if (propField.Count() == 0)
                    write.WriteLine("Таких нет");

                write.WriteLine("\nВСЕ РЕАЛИЗУЕМЫЕ ИНТЕРФЕЙСЫ");
                foreach (var inf in interf)
                    write.WriteLine($"{inf}");
                if (interf.Count() == 0)
                    write.WriteLine("Таких нет");
            }
        }
        static public void InvokeFile(string name, string method, object[] param)
        {
            Type type=Type.GetType(name);
            object instanc= Activator.CreateInstance(type);
            MethodInfo metod = type.GetMethod(method);

            metod.Invoke(instanc, param);
        }
        static public object Generator(Type type)
        {
            if (type == typeof(int))
                return 1234;
            if (type == typeof(string))
                return "5678";

            return null;
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%% F %%%%%%%%%%%%%%%%%%%%%%%%%%%
        static public List<string> GetNeedMetod(Type type, Type locate)
        {
            List<string> result = new List<string>();
            MethodInfo[] mInfo = type.GetMethods();

            foreach (var metods in mInfo)
            {
                bool need = false;
                ParameterInfo[] pInfo = metods.GetParameters();

                foreach (var param in pInfo)
                {
                    if (param.ParameterType == locate)
                    {
                        need = true;
                        break;
                    }
                }

                if (need)
                    result.Add(metods.Name);
            }

            return result;
        }
        //%%%%%%%%%%%%%%%%%%%%%%%%%% LESSON2 %%%%%%%%%%%%%%%%%%%%%%%%%%%
        static public T Creat<T>()
        {
            Type type = typeof(T);

            ConstructorInfo[] constr = type.GetConstructors();

            if (constr.Length == 0)
                throw new Exception("У этого типа нет публичных конструкторов");

            ParameterInfo[] param = constr[0].GetParameters();

            object[] args = new object[param.Length];

            for (int i = 0; i < param.Length; i++)
                args[i] = Activator.CreateInstance(param[i].ParameterType);
        
            T instanse = (T)constr[0].Invoke(args);

            return instanse;
        }
    }
}
