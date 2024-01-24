using MyClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyException;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = "Ivan Ivanovich";
            string name2 = "Ivan ivanovich Ivanov";
            string name3 = "Ivan I Ivanov";
            string name4 = "Ivan Ivan0vich Ivanov";
            string name5 = "Ivan IvaNovich Ivanov";
            string name6 = "Ivan Ivanovich Ivanov"; 

            CreatPeple(name1);
            Console.WriteLine('\n');
            CreatPeple(name2);
            Console.WriteLine('\n');
            CreatPeple(name3);
            Console.WriteLine('\n');
            CreatPeple(name4);
            Console.WriteLine('\n');
            CreatPeple(name5);
            Console.WriteLine('\n');
            CreatPeple(name6);
            Console.WriteLine('\n');
            bool hel = true;
            try
            {
                Peple myName = new Peple("Ia Osel Shrekovich");

                int x = 0;
                int y = 5 / x;

                Console.WriteLine("Здравствуйте {0}", myName.FullName);
            }
            catch (FullNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка не в ФИО\n{0}", ex.Message);
            }

            try
            {
                int[] arr = { 1, 2, 3 };
                Console.WriteLine(arr[3]);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(File.ReadAllText("hello.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Ввеите число < 0: ");
            int numb;
            if(!int.TryParse(Console.ReadLine(), out numb))
                Console.WriteLine("Это не число");

            Debug.Assert(numb < 0);
            Console.WriteLine("Все верно");

            Console.WriteLine('\n');
            Console.ReadLine();
        }

        static void CreatPeple(string name)
        {
            try
            {
                Peple myName = new Peple(name);

                Console.WriteLine("Здравствуйте {0}", myName.FullName);
            }
            catch(LowRigistryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FullNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка не в ФИО\n{0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("На ФИО остановились");
            }
        }
    }
}
