using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using MyPlace;

namespace laba13
{
    class Program
    {
        static void Main()
        {
            const string file1 = "..\\..\\..\\..\\file1.txt";
            const string file2 = "..\\..\\..\\..\\file2.txt";
            const string file3 = "..\\..\\..\\..\\file3.xml";
            const string file4 = "..\\..\\..\\..\\file4.json";
            const string file5 = "..\\..\\..\\..\\ListFile.txt";
            const string file6 = "..\\..\\..\\..\\newFile";
            const string file7 = "..\\..\\..\\..\\HELLO";

            var water1 = new Water(5_000, 40);
            var water2 = new Water(4_500, 56);
            var water3 = new Water(10_000, 2);
            var water4 = new Water(1_234, 98);

            var sea1 = new Sea("hello", 500, water1);
            var sea2 = new Sea("byby", 333, water2);
            var sea3 = new Sea("Good By", 1_200, water3);
            var sea4 = new Sea("bingo", 101, water4);


            try
            {
                SerializeSea.CreatSirialize(sea1, file1, 1);
                var sea01 = SerializeSea.CreatDesirialize(file1, 1);

                SerializeSea.CreatSirialize(sea2, file2, 2);
                var sea02 = SerializeSea.CreatDesirialize(file2, 2);

                SerializeSea.CreatSirialize(sea3, file3, 3);
                var sea03 = SerializeSea.CreatDesirialize(file3, 3);

                SerializeSea.CreatSirialize(sea4, file4, 4);
                var sea04 = SerializeSea.CreatDesirialize(file4, 4);

                Console.WriteLine("Все отработало хорошо");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Sea> seas1 = new List<Sea>();
            List<Sea> seas2 = new List<Sea>();

            seas1.Add(sea1);
            seas1.Add(sea2);
            seas1.Add(sea3);
            seas1.Add(sea4);

            try
            {
                SerializeSea.ListSerilize(file5, seas1);
                seas2 = SerializeSea.ListDeserilize(file5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var item in seas2)
            {
                Console.WriteLine(item.ObjName);
            }

            try
            {
                SerializeSea.ShowByName(file3);
                SerializeSea.ShowByDepth(file3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

            bool end =false;
            while (!end)
            {
                try
                {
                    Console.Clear();
                    SerializeSea.CreateLinqFile(file6, seas2);
                    end = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                } 
            }

            FSea newS = new FSea("Htllo", 700);

            DataContractSerializer ser = new DataContractSerializer(typeof(FSea));

            using (FileStream file = new FileStream(file7+".txt", FileMode.Create))
            {
                ser.WriteObject(file, newS);
            }
            using (FileStream file = new FileStream(file7 + ".txt", FileMode.Open))
            {
                FSea secondS = ser.ReadObject(file) as FSea;
            }
        }
    }
}
