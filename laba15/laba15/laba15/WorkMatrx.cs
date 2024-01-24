using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrx
{
    static class WorkMatrx
    {
        static public void ShowMattrx(int[,] m)
        {
            int row = m.GetLength(0);
            int col = m.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                    Console.Write($"{m[i, j]}\t");
                Console.WriteLine('\n');
            }
        }
        static public int[,] GetRendomMatrx(int lon, int high)
        {
            int[,] matrx = new int[lon, high];
            int row = matrx.GetLength(0);
            int col = matrx.GetLength(1);


            Random ranada=new Random();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    matrx[i, j] = ranada.Next(1, 11);

                    return matrx;
        }
        static  public int[,] CreatMult(int[,] matrxF, int[,] matrxS)
        {
            int row = matrxF.GetLength(0);
            int col = matrxS.GetLength(1);
            int same = matrxF.GetLength(1);

            int[,] result = new int[row, col];

            Task[] schet = new Task[row];

            for (int i = 0; i < row; i++)
            {
                int r = i;

                schet[i] = Task.Run(() =>
                {
                    for (int j = 0;j < col; j++)
                    {
                        int sum = 0;

                        for(int l=0;l<same;l++)
                            sum += (matrxF[r, l] * matrxS[l, j]);

                        result[r, j] = sum;
                    }
                });
            }

            if (row > 1)
                if (schet[1].IsCanceled)
                    Console.WriteLine("Вторая задача завершина");
                else
                    Console.WriteLine("Вторая задача не завершина");

            Task.WaitAll(schet);

            return result;
        }
        static public int[,] CreatMultLong(int[,] matrxF, int[,] matrxS)
        {
            int row = matrxF.GetLength(0);
            int col = matrxS.GetLength(1);
            int same = matrxF.GetLength(1);

            int[,] result = new int[row, col];

            Task[] schet = new Task[row];

            for (int i = 0; i < row; i++)
            {
                int r = i;
                    for (int j = 0; j < col; j++)
                    {
                        int sum = 0;

                        for (int l = 0; l < same; l++)
                            sum += (matrxF[r, l] * matrxS[l, j]);

                        result[r, j] = sum;
                    }
            }


            return result;
        }
        static public int[,] CreatMultEager(int[,] matrxF, int[,] matrxS)
        {
            int row = matrxF.GetLength(0);
            int col = matrxS.GetLength(1);
            int same = matrxF.GetLength(1);

            int[,] result = new int[row, col];

            CancellationTokenSource cancel = new CancellationTokenSource();
            CancellationToken tokend = cancel.Token;

            Task[] schet = new Task[row];

            for (int i = 0; i < row; i++)
            {
                int r = i;

                schet[i] = Task.Run(() =>
                {
                    if(r > 5)
                        cancel.Cancel();
                    if(tokend.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция остановлена");
                        return;
                    }
                    for (int j = 0; j < col; j++)
                    {
                        int sum = 0;

                        for (int l = 0; l < same; l++)
                            sum += (matrxF[r, l] * matrxS[l, j]);

                        result[r, j] = sum;
                    }
                }, tokend);
            }

            Task.WaitAll(schet);

            if (row > 0)
                if (schet[1].IsCanceled)
                    Console.WriteLine("Вторая задача завершина");
                else
                    Console.WriteLine("Вторая задача не завершина");

            return result;
        }
    }
}