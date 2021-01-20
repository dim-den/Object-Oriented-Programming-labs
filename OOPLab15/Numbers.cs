using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace OOPLab15
{
    class Numbers
    {
        private int number;
        private int temp = 0;
        static Mutex mutex = new Mutex();
        static object locker = new object();

        public StreamWriter file = new StreamWriter("oddeven.txt", false);
        public Numbers(int number)
        {
            this.number = number;
        }
        ~Numbers()
        {
            try { file.Close(); }
            catch { };
        }
        public void Even()
        {
            for (int i = 2; i < number; i += 2)
            {
                Thread.Sleep(20);
                Console.WriteLine(i);
            }
        }
        public void Odd()
        {
            for (int i = 1; i < number; i += 2)
            {
                Thread.Sleep(40);
                Console.WriteLine(i);
            }
        }

        public void EvenSync()
        {
            while (temp < number)
            {
                mutex.WaitOne();
                Thread.Sleep(20);
                if (temp % 2 == 0) Console.WriteLine(temp++);
                mutex.ReleaseMutex();
            }
            temp = 0;
        }

        public void OddSync()
        {
            while (temp < number)
            {
                mutex.WaitOne();
                Thread.Sleep(40);
                if (temp % 2 != 0) Console.WriteLine(temp++);
                mutex.ReleaseMutex();
            }
            temp = 0;
        }

        public void EvenSync2()
        {
            lock (locker)
            {
                for (int i = 2; i < number; i += 2)
                {
                    Thread.Sleep(20);
                    Console.WriteLine(i);
                }
            }
        }

        public void OddSync2()
        {
            lock(locker)
            {
                for (int i = 1; i < number; i += 2)
                {
                    Thread.Sleep(40);
                    Console.WriteLine(i);
                }
            }
        }
    }
}


