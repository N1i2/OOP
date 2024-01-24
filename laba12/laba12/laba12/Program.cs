using System;
using MyFile;
using MyDisck;
using MyDirictory;
using MyMenej;
using MyProtakol;

namespace laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyProtakol.Protacol.CreatProtacl();

            int chois;
            bool end = false;
            string[] comand =
            {
                "1 - Добавить текст",
                "2 - Удолить строку",
                "3 - Найти все строки с нужным текстом",
                "4 - Выйти"
            };

            while (!end)
            {
                Console.Clear();
                foreach (string s in comand)
                    Console.WriteLine(s);

                Console.Write("Введите номер своего выбора: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out chois) || chois < 1 || chois > comand.Length)
                        throw new Exception("Это чтосло не подходит");

                    switch (chois)
                    {
                        case 1:
                            string text;
                            Console.WriteLine("Введиет строку которую хотите ввести:");
                            text = Console.ReadLine();
                            WorkWithFile.AppTextFile(text);
                            break;
                        case 2:
                            WorkWithFile.ShowAllFile();

                            int line;
                            Console.WriteLine("Введите номер строки которую хотите удолить");
                            if (!int.TryParse(Console.ReadLine(), out line) || line < 1)
                                throw new IndexOutOfRangeException();

                            WorkWithFile.DeletTextFile(line);
                            break;
                        case 3:
                            Console.WriteLine("Введиет подстроку по которой искать");
                            text = Console.ReadLine();

                            WorkWithFile.LocateText(text);
                            break;
                        case 4:
                            Console.WriteLine("Конец\n");
                            end = true;
                            break;
                    }

                    if (!end)
                    {
                        Console.WriteLine("Команда отработала без ошибок");
                        Console.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            ShowDiskInfo.ShowTotalMemory();
            ShowDiskInfo.ShowDriverFormat();
            ShowDiskInfo.ShowAllDriver();

            try
            {
                Console.ReadLine();
                Console.Clear();

                string first = "..\\..\\..\\SNE-Log.txt";
                string second = "hello";

                ShowFileInfo.ShowFullPath(first);
                ShowFileInfo.ShowFullInfo(first);
                ShowFileInfo.ShowDate(first);

                ShowFileInfo.ShowFullPath(second);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }

            try
            {
                ShowDirictory.ShowAllFile("..\\..\\..");
                ShowDirictory.ShowDateCreat("..\\..\\..");
                ShowDirictory.ShowColPodKotol("..\\..\\..");
                ShowDirictory.ShowAllTopKotol("..\\..\\..");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
            Console.Clear();

            try
            {
                string newAdres = "E:\\универ\\OOP\\laba12";
                string oldAdres = "E:\\универ\\OOP\\laba12\\file1";

                FileMeneger.CreatDirik("E:\\");
                FileMeneger.RecreatDiric(newAdres, oldAdres);
                FileMeneger.CreatZip("E:\\универ\\OOP\\laba12\\file_3");
                FileMeneger.RezipFile("E:\\универ\\OOP\\laba12\\second.zip", "E:\\универ\\OOP\\laba12\\file1");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
            Console.Clear();
            try
            {
                Protacol.ShowDayProtakol("11/17/2023");
                Protacol.ShowTimeProtacol(7);
                Protacol.ShowWordProtacol("доб");
                Protacol.ShowCol();
                Protacol.DeleteOldProtacol();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
