using System.Diagnostics;
using System.IO;

namespace MyProcess
{
    static class WorkWithProces
    {
        static WorkWithProces()
        {
            adres = "..\\..\\..\\file";
            count = 0;
        }

        static private string adres;
        static private int count;
        static public void WriteAllInform()
        {
            using (StreamWriter file = File.CreateText(adres + (++count) + ".txt"))
            {
                int numb = 0;
                foreach (Process proc in Process.GetProcesses())
                {
                    file.WriteLine("Процесс №{0}", ++numb);
                    file.WriteLine("Имя процесса: {0}", proc.ProcessName);
                    file.WriteLine("Id процесса: {0}", proc.Id);
                    file.WriteLine("Приорететность процесса: {0}", proc.PriorityClass);
                    file.WriteLine("Время запуска процесса: {0}", proc.StartTime);
                    file.WriteLine("Текущее состояние процесса: {0}", proc.Responding);
                    file.WriteLine("Время работы процесса: {0}\n", proc.TotalProcessorTime);
                }
            }
        }
    }
}