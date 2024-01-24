using System;
using System.IO;
using System.Linq;

namespace MyDisck
{
    static class ShowDiskInfo
    {
        static ShowDiskInfo()
        {
            drivInfo = DriveInfo.GetDrives();
        }

        static private DriveInfo[] drivInfo { get; set; }

        static public bool LocateName(string name)
        {
            foreach (var item in drivInfo)
                if (item.Name == name)
                    return true;

            return false;
        }
        static public string[] GetNames()
        {
            return drivInfo.Select(name => name.Name).ToArray();
        }
        static public void ShowTotalMemory()
        {
            Console.WriteLine("\nМесто на дисках");
            foreach (var d in drivInfo)
                Console.WriteLine($"{d.Name} == {d.TotalFreeSpace} байт");
        }
        static public void ShowDriverFormat()
        {
            Console.WriteLine("\nФормат файловой системы");
            foreach (var d in drivInfo)
                Console.WriteLine($"{d.Name} == {d.DriveFormat}");
        }
        static public void ShowAllDriver()
        {
            Console.WriteLine("\nВся инфа о дисках");
            foreach (var disk in drivInfo)
            {
                Console.WriteLine($"{disk.Name}, " +
                    $"полная память {disk.TotalSize} байт, " +
                    $"свободная память {disk.AvailableFreeSpace} байт, " +
                    $"метка тома {disk.VolumeLabel}");
            }
        }
    }
}
