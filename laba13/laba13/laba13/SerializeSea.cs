using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using laba13;

namespace MyPlace
{
    static class SerializeSea
    {
        static public void CreatSirialize(Sea elem, string adres, int howSirel)
        {
            if (elem == null)
                throw new Exception("Переданные данные не верны");

            using (FileStream file = new FileStream(adres, FileMode.Create))
            {
                if (howSirel == 1)
                {
                    BinaryFormatter form = new BinaryFormatter();
                    form.Serialize(file, elem);
                }
                else if (howSirel == 2)
                {
                    SoapFormatter form = new SoapFormatter();
                    form.Serialize(file, elem);
                }
                else if (howSirel == 3)
                {
                    XmlSerializer form = new XmlSerializer(typeof(Sea));
                    form.Serialize(file, elem);
                }
                else if (howSirel == 4)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    };
                    JsonSerializer.Serialize(file, elem, options);
                }
                else
                    Console.WriteLine("Такой серилизации не предусмотренно");
            }
        }
        static public Sea CreatDesirialize(string adres, int howSirel)
        {
            if (!File.Exists(adres))
                throw new FileNotFoundException();

            Sea result;

            using (FileStream file = new FileStream(adres, FileMode.Open))
            {
                if (howSirel == 1)
                {
                    BinaryFormatter form = new BinaryFormatter();
                    result = form.Deserialize(file) as Sea;
                }
                else if (howSirel == 2)
                {
                    SoapFormatter form = new SoapFormatter();
                    result = form.Deserialize(file) as Sea;
                }
                else if (howSirel == 3)
                {
                    XmlSerializer form = new XmlSerializer(typeof(Sea));
                    result = form.Deserialize(file) as Sea;
                }
                else if (howSirel == 4)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    };
                    result = JsonSerializer.Deserialize<Sea>(file, options);
                }
                else
                    result = null;
            }

            if (result == null)
                throw new Exception("Файло не удоеться дисерилизовать");

            return result;
        }

        static public void ListSerilize(string adres, List<Sea> seas)
        {
            using (FileStream file = new FileStream(adres, FileMode.Create))
            {
                SoapFormatter form = new SoapFormatter();

                form.Serialize(file, seas);
            }
        }
        static public List<Sea> ListDeserilize(string adres)
        {
            if (!File.Exists(adres))
                throw new Exception("Такого файла нет");

            List<Sea> list = new List<Sea>();
            SoapFormatter form = new SoapFormatter();

            using (FileStream file = new FileStream(adres, FileMode.Open))
            {
                list = form.Deserialize(file) as List<Sea>;
            }

            if (list == null)
                throw new Exception("Файла не удоеться дисерилизовать");

            return list;
        }
        static private void ShowSelector(string adres, string how)
        {
            XmlDocument file = new XmlDocument();
            file.Load(adres);
            XmlElement elem = file.DocumentElement;
            XmlNodeList list = elem.SelectNodes(how);

            if (list.Count == 0)
                throw new Exception("Таких элементов нет");

            Console.WriteLine("Все элементы селектора \"{0}\"", how);
            foreach (XmlNode item in list)
                Console.WriteLine(item.OuterXml);
        }

        static public void ShowByName(string adres)
        {
            ShowSelector(adres, "ObjName");
        }
        static public void ShowByDepth(string adres)
        {
            ShowSelector(adres, "MaxDepth");
        }

        static public void CreateLinqFile(string adres, List<Sea> seas)
        {
            int how;

            Console.Write("Введите что искать(1 - все моря определенной глубины," +
                " 2 - все моря начинающиеся с определенного символа):\t");
            if (!int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out how) || (how != 1 && how != 2))
                throw new Exception("Такого варианта нет");
            Console.WriteLine();

            int need;

            Console.Write("введите куда сохронять(1 - xml, 2 - json):");
            if (!int.TryParse(Convert.ToString(Console.ReadKey().KeyChar), out need) || (need != 1 && need != 2))
                need = 1;
            Console.WriteLine();

            if (need == 1)
                XmlWork(adres, how, seas);
            else
                JsonWork(adres, how, seas);
        }

        static private void JsonWork(string adres, int how, List<Sea> seas)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            using (FileStream file = new FileStream(adres + "\\..\\allList.json", FileMode.Create))
                JsonSerializer.Serialize(file, seas, options);

            List<Sea> result;

            using (FileStream file = new FileStream(adres + ".json", FileMode.Create))
            {
                if (how == 1)
                {
                    int depth;
                    Console.Write("Введите минимальную глубину:\t");
                    if (!int.TryParse(Console.ReadLine(), out depth))
                        depth = 0;
                    Console.WriteLine();

                    result = seas.Where(sea => sea.MaxDepth >= depth).ToList();
                }
                else
                {
                    Console.WriteLine("Введите начальный символ");
                    char sim = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    result = seas.Where(sea => sea.ObjName[0] == sim).ToList();
                }

                JsonSerializer.Serialize(file, result, options);
            }
        }

        static private void XmlWork(string adres, int how, List<Sea> seas)
        {
            XDocument start = new XDocument
            (
                new XElement("Root",
                    from sea in seas
                    select new XElement
                    (
                        "Sea",
                        new XElement("Name", sea.ObjName),
                        new XElement("Depth", sea.MaxDepth)
                    )
                )
            );
            start.Save(adres + "\\..\\allList.xml");

            XDocument end = XDocument.Load(adres + "\\..\\allList.xml");
            XDocument result = new XDocument(new XElement("Root"));

            if (how == 1)
            {
                int depth;
                Console.Write("Введите минимальную глубину:\t");
                if (!int.TryParse(Console.ReadLine(), out depth))
                    depth = 0;
                Console.WriteLine();

                result.Root.Add
                (
                    from sea in end.Descendants("Sea")
                    where (int)sea.Element("Depth") >= depth
                    select new XElement
                    (
                        "Sea",
                        new XElement(sea.Element("Name")),
                        new XElement(sea.Element("Depth"))
                    )
                );
            }
            else
            {
                Console.WriteLine("Введите начальный символ");
                char sim = Console.ReadKey().KeyChar;
                Console.WriteLine();

                result.Root.Add
                (
                    from sea in end.Descendants("Sea")
                    where Convert.ToString(sea.Value)[0] == sim
                    select new XElement
                    (
                        "Sea",
                        new XElement(sea.Element("Name")),
                        new XElement(sea.Element("Depth"))
                    )
                );
            }
            result.Save(adres + ".xml");
        }
    }
}
