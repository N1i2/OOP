using System;
using System.Linq;
using MyMetod;
using MyLine;
using System.Collections.Generic;
using MyInfo;

//integrate

namespace laba10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] mounth =
                   {
                "December",
                "Junuary",
                "February",
                "March",
                "april",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "november"
            };

                Console.WriteLine("Все месяцы");
                HelpStaticMetod.ShowInfo(mounth);

                try
                {
                    int sizeWord;

                    Console.Write("Введите длинну искомых слов: ");

                    if (!int.TryParse(Console.ReadLine(), out sizeWord))
                        throw new Exception("Это не число");

                    Console.WriteLine($"\n\nВсе месяцы длинны {sizeWord}".PadLeft(60, '='));

                    HelpStaticMetod.ShowInfo(mounth.Where((word) => word.Length == sizeWord).ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                };

                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("\n\nТолько зимние и летние".PadLeft(60, '='));
                HelpStaticMetod.ShowInfo(mounth.Take(3).ToArray());
                HelpStaticMetod.ShowInfo(mounth.Skip(6).Take(3).ToArray());

                Console.WriteLine("\n\nМесяцы в афовитнм порядке:".PadLeft(60, '='));
                HelpStaticMetod.ShowInfo(mounth.OrderBy((word) => Convert.ToString(word[0]).ToUpper()).ToArray());

                Console.WriteLine("\n\nДлинной > 4 и имеющее букву \'u\'".PadLeft(60, '='));
                HelpStaticMetod.ShowInfo(mounth.Where((word) => word.Length > 4).Where((word) =>
                {
                    for (int i = 0; i < word.Length; i++)
                        if (word[i] == 'u')
                            return true;
                    return false;
                }).ToArray());

                List<AirLine> lines = new List<AirLine>();

                lines.Add(new AirLine("", "", 30.28, 17, 0));
                lines.Add(new AirLine("hello", "Аляска", 16.22, 4, 5));
                lines.Add(new AirLine("12", "Кудато", 12.12, 12, 16));
                lines.Add(new AirLine("bebebe", "", 0, 0, 0));
                lines.Add(new AirLine("Ia ustal", "Никуда", -77, 101, 6));
                lines.Add(new AirLine("", "Туда где нас нет", 0.15, 7, 7));
                lines.Add(new AirLine("", "", 30, 1, 2));
                lines.Add(new AirLine("", "Мадагаскар", 31.01, 3, 3));
                lines.Add(new AirLine("Именно туда", "53.841812,27.570515", 32.30, 4, 4));
                lines.Add(new AirLine("", "", 33.08, 5, 5));

                Console.ReadLine();
                Console.Clear();

                HelpStaticMetod.ShowLine(lines.ToArray());

                string punkt = "Домой";
                int dayOfWeak = 2;
                int tip = 1;

                AirLine[] needPlase = new AirLine[] { };

                Console.Read();
                Console.Clear();

                needPlase = lines.Where((line) => line.Punkt == punkt).ToArray();
                Console.WriteLine("\nЕдут в {0}".PadLeft(60, '='), punkt);
                HelpStaticMetod.ShowLine(needPlase);
                Console.ReadLine();
                Console.ReadLine();
                Console.Clear();

                needPlase = lines.Where((line) => (int)line.day == dayOfWeak).ToArray();
                Console.WriteLine("\nЕдут в {0} дeнь недели".PadLeft(60, '='), dayOfWeak);
                HelpStaticMetod.ShowLine(needPlase);
                Console.ReadLine();
                Console.Clear();

                AirLine maxRise = needPlase.OrderBy(line => line.rise).FirstOrDefault();
                Console.WriteLine("Наибольший = {0}", maxRise.Name);
                Console.ReadLine();
                Console.Clear();

                needPlase = lines.GroupBy(line => line.day).
                    SelectMany(grup => grup.Where(line => line.chackTime == grup.Max(l => l.chackTime))).
                    OrderBy(line => line.day).ToArray();
                Console.WriteLine("\nСамые поздние на каждый день недели".PadLeft(60, '='));
                HelpStaticMetod.ShowLine(needPlase);
                Console.ReadLine();
                Console.Clear();

                needPlase = lines.OrderBy(line => line.day).ThenBy(line => line.chackTime).ToArray();
                Console.WriteLine("\nОтсортированные".PadLeft(60, '='));
                HelpStaticMetod.ShowLine(needPlase);
                Console.ReadLine();
                Console.Clear();

                int result = lines.Count(line => (int)line.tip == tip - 1);
                Console.WriteLine("\nКоличество рейсов для самолета типа {0}".PadLeft(60, '='), tip);
                Console.WriteLine(result);
                Console.ReadLine();
                Console.Clear();

                var fiveOper =
                    lines.Where(line => line.rise > 5).
                    OrderBy(line => line.day).
                    ThenBy(line => line.chackTime).
                    Select(line => new
                    {
                        line.Name
                    }).
                    Take(3).Skip(2);

                foreach (var item in fiveOper)
                    Console.WriteLine("Едим {0}", item.Name);

                var info = new NewInfo[3];

                info[0] = new NewInfo("", "", 120);
                info[1] = new NewInfo("", "hello", -30);
                info[2] = new NewInfo("Кудато", "Hi", 210);


                var lastRes = lines.
                    Where(line => line.Punkt == punkt).
                    Join(info, line =>
                    line.Punkt, inf => inf.Punkt,
                    (line, inf) => new
                    {
                        punkt = line.Punkt,
                        Name = inf.Sluge,
                        lName = line.Name,
                        price = inf.Price
                    }
                ).ToArray();

                Console.Read();
                Console.Clear();

                Console.WriteLine("Все что идет домой");

                foreach (var item in lastRes)
                    Console.WriteLine("Вы летитев {0} на {1} и вас обслужат {2} за {3}$", item.punkt, item.lName, item.Name, item.price);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}