using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace OOPLab13
{
    public static class DDAFileManager
    {
        public static void TaskA(string disk_name)
        {
            DDALog.WriteHead($"DDAFileManager.TaskA files and subdirictories in disk {disk_name}");

            string[] dirs = Directory.GetDirectories(disk_name);
            string[] files = Directory.GetFiles(disk_name);

            string path = @"C:\Users\dimde\OneDrive\Рабочий стол\ООТП\OOPLab13\OOPLab13";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("DDAInspect");

            FileInfo file = new FileInfo(directory.FullName + "\\DDAInspect\\DDAdirinfo.txt");
            using (StreamWriter sw = new StreamWriter(file.FullName))
            {
                sw.WriteLine("Subdirectories:");
                foreach (string s in dirs)
                    sw.WriteLine(s);
                sw.WriteLine("Files:");
                foreach (string s in files)
                    sw.WriteLine(s);
            }
            File.Copy(file.FullName, file.DirectoryName + "\\dirinfo_copy.txt", true);
            file.Delete();
        }

        public static void TaskB(string path, string extension)
        {
            DDALog.WriteHead($"DDAFileManager.TaskB files with extension {extension} at {path}");

            DirectoryInfo source = new DirectoryInfo(path);
            if (Directory.Exists(path + "DDAFiles")) Directory.Delete(path + "DDAFiles");
            source.CreateSubdirectory("DDAFiles");
            string path_to_inspect = @"C:\Users\dimde\OneDrive\Рабочий стол\ООТП\OOPLab13\OOPLab13\DDAInspect\DDAFiles";

            foreach (FileInfo item in source.GetFiles())
            {
                if(item.Extension == extension) item.CopyTo(source + "\\DDAFiles\\" + item.Name, true);
            }

            if (!Directory.Exists(path_to_inspect)) Directory.Move(path + "\\DDAfiles", path_to_inspect);
            
        }
        
        public static void TaskC()
        {
            DDALog.WriteHead("DDAFileManager.TaskC archieving");
            string path = @"C:\Users\dimde\OneDrive\Рабочий стол\ООТП\OOPLab13\OOPLab13\DDAInspect\DDAFiles";

            DirectoryInfo directory = new DirectoryInfo(path);
            if (!File.Exists(@"C:\Users\dimde\OneDrive\Рабочий стол\ООТП\OOPLab13\OOPLab13\DDAInspect\DDAFiles.zip"))
            {
                ZipFile.CreateFromDirectory(directory.FullName, directory.FullName + ".zip");
            }

            using (ZipArchive zip = new ZipArchive(File.Open(directory.FullName + ".zip", FileMode.Open)))
            {
                DirectoryInfo buf = new DirectoryInfo(@"C:\Users\dimde\OneDrive\Рабочий стол\ООТП\OOPLab13\OOPLab13\DDAInspect");
                foreach (ZipArchiveEntry x in zip.Entries)
                    x.ExtractToFile(buf.FullName + '\\' + x.Name, true);
            }
        }       
    }
}
