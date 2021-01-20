using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOPLab13
{
    internal static class DDADiskInfo
    {
        private static readonly DriveInfo[] AllDisk = DriveInfo.GetDrives();

        public static void DiskFreeSpace(string name)
        {
            DDALog.WriteHead("DDADiskInfo.DiskFreeSpace :\\" + name);
            DDALog.WriteMessage(name);
            name = name + ":\\";
            DDALog.WriteMessage(name);
            foreach (DriveInfo disk in AllDisk)
            {
                if (disk.Name == name)
                {
                    DDALog.WriteMessage($"Name disk:{disk.Name}");
                    if (disk.IsReady)
                    {
                        DDALog.WriteMessage($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} GB\n");
                    }
                }
            }
            DDALog.WriteMessage("-----------------------------------------------------------------------------------\n");
        }
        public static void FileSystemInfo()
        {   
            DDALog.WriteHead("DDADiskInfo.FileSystemInfo");
            foreach (DriveInfo disk in AllDisk)
            {
                DDALog.WriteMessage($"Drive name: {disk.Name}, drive type: {disk.DriveType}");
            }
            DDALog.WriteMessage("\n-----------------------------------------------------------------------------------\n");
        }
        public static void AllDisksInfo()
        {
            DDALog.WriteHead("DDADiskInfo.AllDisksInfo");
            foreach (DriveInfo disk in AllDisk)
            {
                DDALog.WriteMessage($"Name disk:{disk.Name}");
                if (disk.IsReady)
                {
                    DDALog.WriteMessage($"Total size: {disk.TotalSize / 1024 / 1024 / 1024} GB");
                    DDALog.WriteMessage($"Free space: {disk.TotalFreeSpace / 1024 / 1024 / 1024} GB");
                    DDALog.WriteMessage($"FileSystem:{disk.RootDirectory}");
                    DDALog.WriteMessage($"VolumeLabel:{disk.VolumeLabel}");
                    DDALog.WriteMessage($"DriveType:{disk.DriveType}\n");
                }
            }
            DDALog.WriteMessage("-----------------------------------------------------------------------------------\n");
        }
    }
}
