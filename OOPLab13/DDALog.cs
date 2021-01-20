using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOPLab13
{
    public static class DDALog
    {

        private static StreamWriter writer = new StreamWriter("DDAlogfile.txt", true);

        public static void WriteHead(string msg)
        {
            writer.WriteLine(msg + ", time: " + DateTime.Now.ToString());
        }
        public static void WriteMessage(string msg)
        {
            writer.WriteLine(msg);
        }

        public static void FindByDay(string day)
        {
            if (Convert.ToInt32(day) > 31 || Convert.ToInt32(day) < 0) throw new Exception("Wrong day");
            writer.Close();
            string line;
            bool flag = false;        
            using (StreamReader reader = new StreamReader("DDAlogfile.txt"))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Contains("time: " + day)) {
                        if (!flag) Console.WriteLine($"Events that happened in day number {day}:");
                        flag = true; Console.WriteLine(line);
                    }
                }
            }
            if (!flag) Console.WriteLine($"There is no eventS happened in day number {day}");
            Console.WriteLine("\n---------------------------------------------------------------------------------");
            writer = new StreamWriter("DDAlogfile.txt", true);
        }

        public static void FindByTime(string hour1, string hour2)
        {
            int h1 = Convert.ToInt32(hour1), h2 = Convert.ToInt32(hour2);
            if ( h1 > 23 ||h1 < 0 || h2 > 23 || h2 < 0 || h2 < h1) throw new Exception("Wrong hour");
            writer.Close();
            string line;
            bool flag = false;
            using (StreamReader reader = new StreamReader("DDAlogfile.txt"))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Contains("time: "))
                    {
                        int hour = Convert.ToInt32(line.Substring(line.Length - 8, 2));
                        if(hour <= h2 && hour >= h1) {
                            if (!flag) Console.WriteLine($"Events that happened between {hour1} and {hour2} hours:");
                            flag = true; Console.WriteLine(line);
                        }
                    }
                }
            }
            if (!flag) Console.WriteLine($"There is no evenets that happened between {hour1} and {hour2} hours");
            Console.WriteLine("\n---------------------------------------------------------------------------------");
            writer = new StreamWriter("DDAlogfile.txt", true);
        }

        public static void FindByWord(string word)
        {
            writer.Close();
            string line;
            bool flag = false;
            using (StreamReader reader = new StreamReader("DDAlogfile.txt"))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Contains(word))
                    {
                        if (!flag) Console.WriteLine($"Lines that contains key word '{word}':");
                        flag = true; Console.WriteLine(line);
                    }
                }
            }
            if (!flag) Console.WriteLine($"There is no lines that contains key word '{word}'");
            Console.WriteLine("\n---------------------------------------------------------------------------------");
            writer = new StreamWriter("DDAlogfile.txt", true);
        }

        public static int CountRecords()
        {
            writer.Close();
            int count = 0;
            string line;
            using (StreamReader reader = new StreamReader("DDAlogfile.txt"))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Contains(", time:" ))
                    {
                        count++;
                    }
                }
            }
            writer = new StreamWriter("DDAlogfile.txt", true);
            return count;
        }

        public static void ClearToLastHour()
        {
            writer.Close();
            int count = 0;
            var last_time = DateTime.Now.AddHours(-1);
            bool flag = false;
            string line;
          
            using (StreamReader reader = new StreamReader("DDAlogfile.txt"))
            {
                using (StreamWriter temp = new StreamWriter("DDAlogfiletemp.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        if (!flag)
                        {
                            if (line.Contains(", time:"))
                            {
                                var date = DateTime.Parse(line.Substring(line.Length - 19, 19));
                                if (date >= last_time)
                                {
                                    temp.WriteLine(line);
                                    flag = true;
                                }

                            }
                        }
                        else temp.WriteLine(line);
                    }
                }
            }
            File.Delete("DDAlogfile.txt");
            File.Move("DDAlogfiletemp.txt", "DDAlogfile.txt");
            File.Delete("DDAlogfiletemp.txt");
            writer = new StreamWriter("DDAlogfile.txt", true);
        }
        public static void Close()
        {
            writer.Close();
        }
    }
}
