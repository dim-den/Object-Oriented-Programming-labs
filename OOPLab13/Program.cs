using System;

namespace OOPLab13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DDADiskInfo.DiskFreeSpace("D");
                DDADiskInfo.FileSystemInfo();
                DDADiskInfo.AllDisksInfo();

                DDAFileInfo file = new DDAFileInfo(@"C:\Users\dimde\OneDrive\Рабочий стол\arp-ping.exe");
                file.FileInfo();
                DDADirInfo dir = new DDADirInfo(@"C:\Users\dimde\OneDrive\Рабочий стол\ООТП\OOPLab13\OOPLab13");
                dir.DirInfo();
                DDAFileManager.TaskA("D:\\");
                DDAFileManager.TaskB(@"C:\Users\dimde\OneDrive\Рабочий стол\ЯП\Лабараторные\ЛР17_18(14,15)\LPLab14\LPLab14", ".cpp");
                DDAFileManager.TaskC();

                DDALog.FindByDay("13");
                DDALog.FindByTime("16", "17");
                DDALog.FindByWord("DDADirInfo.DirInfo, directory:");
                Console.WriteLine($"Records written in log file: {DDALog.CountRecords()}");
                DDALog.ClearToLastHour();
                DDALog.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Exception: {exc.Message} at {exc.Source}");
            }


        }

    }
}
