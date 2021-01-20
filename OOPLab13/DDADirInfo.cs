using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOPLab13
{
    class DDADirInfo
    {
        private DirectoryInfo dir;
        public DDADirInfo(string directory)
        {
            dir = new DirectoryInfo(directory);
        }
        public void DirInfo()
        {
            DDALog.WriteHead($"DDADirInfo.DirInfo, directory: {dir.Name}");
            if (dir.Exists)
            {
                DDALog.WriteMessage($"Full path: {dir.FullName}");
                DDALog.WriteMessage($"Number of files: {dir.GetFiles().Length}");
                DDALog.WriteMessage($"Time creation: {dir.CreationTime}");
                DDALog.WriteMessage($"Number of subdirectories: {dir.GetDirectories().Length}");
                DDALog.WriteMessage($"List of parent directories of subdirectories: {ParentList()}");
                ParentList();
                DDALog.WriteMessage("-----------------------------------------------------------------------------------\n");
            }
        }
        private string ParentList()
        {
            string result = "";
            DirectoryInfo temp = new DirectoryInfo(dir.FullName);
            while (temp != null)
            {
                result += temp.Name + " ";
                temp = temp.Parent;
                if (temp != null) result += "-> "; 
            }
            return result;
        }
    }
}
