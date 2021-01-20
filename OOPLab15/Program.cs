using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;

namespace OOPLab15
{
    class Program
    {
        public static void SimpleNumbers(object n_)
        {
            int n = (int)n_;
            Console.WriteLine("Thread name: " + Thread.CurrentThread.Name);
            Console.WriteLine("Thread priority: " + Thread.CurrentThread.Priority.ToString());
            Console.WriteLine("Thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("Thread state: " + Thread.CurrentThread.ThreadState.ToString());
            StreamWriter fout = new StreamWriter("easynumbers.txt");
            bool flag;
            for (int i = 2; i < (int)n + 1; i++)
            {
                Thread.Sleep(10);
                flag = true;
                for (int j = i; j > 0; j--)
                    if ((i % j == 0) && (j != 1) && (j != i))
                    {
                        flag = false;
                        break;
                    }
                if (flag == true)
                {
                    fout.WriteLine(i);
                    Console.Write(i + " ");
                }
            }
            fout.Close();
        }
        public static int sec = 15;
        public static void Destruction(object obj)
        {
            if (sec > 0) Console.WriteLine($"Время до удаления Windows: {sec--}с");
            else if (sec == 0) { Console.WriteLine("БШААШШАШФЫВШФ. Windows уничтожена"); sec--; }
            else Console.WriteLine("ERROR 404");
        }
        static void Main(string[] args)
        {
            #region task1
            Process[] proc = Process.GetProcesses();
            foreach (Process x in proc)
            {
                try
                {
                    Console.WriteLine("Process ID: " + x.Id.ToString());
                    Console.WriteLine("Process name: " + x.ProcessName);
                    Console.WriteLine("Priority: " + x.BasePriority.ToString());
                    Console.WriteLine("Start time: " + x.StartTime.ToString());
                    Console.WriteLine("Work time: " + x.TotalProcessorTime.ToString());
                    Console.WriteLine();
                }
                catch
                {
                }
            }
            #endregion

            #region task2
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine("Assemblies:");
            foreach (var el in domain.GetAssemblies())
                Console.WriteLine(el);
            Console.WriteLine();

                //AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
                //Assembly temp = newDomain.Load("OOPLab15");
                //AppDomain.Unload(newDomain);
                //Console.WriteLine(temp.ToString());
            #endregion

            #region task3
            Thread mythread = new Thread(new ParameterizedThreadStart(SimpleNumbers));
            mythread.Name = "Some thread";
            mythread.Priority = ThreadPriority.Highest;
            mythread.Start(50);

            Console.WriteLine("\n--------------------------------------------------------------------------\n"); Console.ReadKey();

            Numbers numbers = new Numbers(27);
            Thread th1 = new Thread(new ThreadStart(numbers.Even));
            Thread th2 = new Thread(new ThreadStart(numbers.Odd));
            th1.Start();
            th2.Priority = ThreadPriority.AboveNormal;
            th2.Start();

            Console.WriteLine("\n--------------------------------------------------------------------------\n"); Console.ReadKey();

            Thread th3 = new Thread(new ThreadStart(numbers.EvenSync));
            Thread th4 = new Thread(new ThreadStart(numbers.OddSync));
            th3.Start();
            th4.Start();

            Console.WriteLine("\n--------------------------------------------------------------------------\n"); Console.ReadKey();

            Thread th5 = new Thread(new ThreadStart(numbers.EvenSync2));
            Thread th6 = new Thread(new ThreadStart(numbers.OddSync2));
            th5.Start();
            th6.Start();

            Console.WriteLine("\n--------------------------------------------------------------------------\n"); Console.ReadKey();
            TimerCallback timerCallback = new TimerCallback(Destruction);
            Timer timer = new Timer(timerCallback, 0, 0, 1000);
        }
        #endregion
    }
}

