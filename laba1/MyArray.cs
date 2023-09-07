using System;

namespace Worcks
{
    internal class MyArray
    {
        public static void Modul()
        {
            //двумерный масив
            const int SIZE = 10;
            int[,] Arr = new int[SIZE, SIZE];

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                    Console.Write($"{Arr[i, j]} ");
                Console.WriteLine();
            }

            Console.WriteLine('\n');

            //заена символа в строке
            string[] texts =
            {
                "hello",
                "how",
                "are",
                "you"
            };

            foreach (string text in texts)
            {
                Console.WriteLine(text);
            }
            Console.WriteLine(texts.Length);

            if (LocateWord(texts))
            {
                Console.WriteLine("\nВсе хорошо");

                foreach (string text in texts)
                {
                    Console.WriteLine(text);
                }
            }
            else
                Console.WriteLine("Произошла ошибка");

            Console.WriteLine();
            //Ступенчатый масив
            double[][] dblArray = new double[3][];

            /* for (int strt = 0, end = 0, value = 11;
                 (end != 3 || strt != 4);
                 value++, strt++)
             {
                 if (strt == end + 1 || end == 0)
                 {
                     dblArray[end] = new double[end + 2];
                     end++;
                     strt = 0;
                 }
                 dblArray[end - 1][strt] = ((double)value / 10d);
             }*/

            for (int i = 0; i < dblArray.Length; i++)
            {
                dblArray[i] = new double[i + 2];
                for (int j = 0; j < dblArray[i].Length; j++)
                {
                    Console.Write($"Введите число [{i}][{j}]: ");
                    if (!double.TryParse(Console.ReadLine(), out dblArray[i][j]))
                    {
                        Console.WriteLine("Ошибка");
                        j--;
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < dblArray.Length; i++)
            {
                for (int j = 0; j < dblArray[i].Length; j++)
                    Console.Write($"[{i}][{j}]{dblArray[i][j]} ");
                Console.WriteLine();
            }

            Console.WriteLine();

            //масив и строка без типа
            var noTipsArray = new object[SIZE];

            for (int i = 0; i < SIZE; i++)
            {
                noTipsArray[i] = i + 1;
                //noTipsArray[i] = (char)(i + 97);
            }

            for (int i = 0; i < SIZE; i++)
            {
                Console.WriteLine(noTipsArray[i]);
            }

            var noTipsString = "";
            //noTipsString = 7;
            noTipsString = "hello";
            Console.WriteLine(noTipsString);

            Console.Read();
        }

        static bool LocateWord(string[] texts)
        {
            Console.Write("Какое слово хотите поменть: ");
            int wordeIndex = Convert.ToInt32(Console.ReadLine());

            if (--wordeIndex > texts.Length || wordeIndex < 0)
                return false;

            Console.Write("Какой символ посчетыу вы хотите заменить: ");

            int simbleNumber = Convert.ToInt32(Console.ReadLine());

            if (--simbleNumber > texts[wordeIndex].Length || simbleNumber < 0)
                return false;

            texts[wordeIndex] = SwapSimble(word: texts[wordeIndex], simbleNumber);

            return true;
        }

        static string SwapSimble(string word, int numbSimbleb)
        {
            word = word.Remove(numbSimbleb, 1);

            Console.Write("Введите символ на который хотитепоменять: ");

            word = word.Insert(numbSimbleb, Convert.ToString(Console.ReadKey().KeyChar));

            return word;
        }
    }
}