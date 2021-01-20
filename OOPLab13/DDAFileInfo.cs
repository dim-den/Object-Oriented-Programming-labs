using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOPLab13
{
    public class DDAFileInfo
    {
        private FileInfo fileInfo;
        public DDAFileInfo(string file_name)
        {
            fileInfo = new FileInfo(file_name);
        }

        public void FileInfo()
        {
            DDALog.WriteHead($"DDAFileInfo.FileInfo, file: {fileInfo.Name}");
            if (fileInfo.Exists)
            {
                DDALog.WriteMessage($"File path: {fileInfo.FullName}");
                DDALog.WriteMessage($"Size: {fileInfo.Length} bytes");
                DDALog.WriteMessage($"Extension: {fileInfo.Extension}");
                DDALog.WriteMessage($"Name: {fileInfo.Name}");
                DDALog.WriteMessage($"File path: {fileInfo.FullName}");
                DDALog.WriteMessage($"Creation time: {fileInfo.CreationTime}");
                DDALog.WriteMessage($"Last change time: {fileInfo.LastWriteTime}");
            }
            DDALog.WriteMessage("-----------------------------------------------------------------------------------\n");
        }
    }
}
