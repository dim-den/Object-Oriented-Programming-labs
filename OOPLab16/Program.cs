using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace OOPLab16
{
    class Program
    {

        static void Task1()
        {
            Random random = new Random();
            int size = 100000000;
            List<int> lst = new List<int>();
            for (int i = 0; i < size; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Task1 stopped");
                    return;
                }
                else lst.Add(i * random.Next(1, 8));
            }

        }
        public static Random rnd = new Random();
        public static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public static CancellationToken token = cancelTokenSource.Token;
        static void Main(string[] args)
        {
            #region task1/2

            Stopwatch watch = Stopwatch.StartNew();
            Task task1 = new Task(Task1);
            task1.Start();

            Console.WriteLine("Current task ID: " + Task.CurrentId.ToString());
            Console.WriteLine("Task Completed: " + task1.IsCompleted.ToString());
            Console.WriteLine("Status: " + task1.Status.ToString());

            Console.WriteLine("Write 'stop' to cancel task1");
            if (Console.ReadLine().ToLower() == "stop") cancelTokenSource.Cancel();

            task1.Wait();
            task1.Dispose();
            watch.Stop();
            Console.WriteLine("Time for task: " + watch.Elapsed);
            #endregion task1/2

            #region task3/4
            Task<int> chain1 = new Task<int>(() => rnd.Next(-100, 100));
            Task<int> chain2 = chain1.ContinueWith((task) => rnd.Next(-100, 100));
            Task<int> chain3 = chain2.ContinueWith((task) => rnd.Next(-100, 100));
            Task<int> chain4 = chain3.ContinueWith((task) => (chain1.Result + chain2.Result + chain3.Result) / 3);
            chain1.Start();
            Console.WriteLine("First Value: " + chain1.Result);
            Console.WriteLine("Second Value: " + chain2.Result);
            Console.WriteLine("Third Value: " + chain3.Result);
            Console.WriteLine("Average: " + chain4.Result);
            chain1.Dispose();
            chain2.Dispose();
            chain3.Dispose();
            chain4.Dispose();

            Task<int> what = Task.Run(() => Enumerable.Range(1, 10000).Count(n => (n % 7 == 0)));
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() => { Console.WriteLine("Task complited with result: " + what.Result); }); //4

            Console.ReadKey();
            #endregion

            #region task5
            Stopwatch st = new Stopwatch();
            int size = 100000000;
            int[] arr1 = new int[size];
            int[] arr2 = new int[size];
            Random random = new Random();
            st.Restart();
            for (int i = 0; i < size; i++)
            {
                arr1[i] = i + 5;
                arr2[i] = i % 10;
            }
            st.Stop();
            Console.WriteLine("for: " + st.Elapsed);
            st.Restart();
            Parallel.For(0, size, i =>
            {
                arr1[i] = i  + 5;
                arr2[i] = i % 10;
            });
            st.Stop();
            Console.WriteLine("ParallelFor: " + st.Elapsed);
            st.Restart();
            UInt64 sum = 0;
            foreach(int el in arr1)
            {
                sum += (UInt64)el;
            }
            st.Stop();
            Console.WriteLine("Foreach: " + st.Elapsed);
            st.Restart();
            sum = 0;
            Parallel.ForEach(arr1, el =>
            {
                sum += (UInt64)el;
            });
            st.Stop();
            Console.WriteLine("ParallelForEach: " + st.Elapsed);
            #endregion

            #region task6
            Parallel.Invoke(() => factorial(10),
                () =>
                {
                    int[] mass = new int[size];
                    for (int i = 0; i < size; i++) { mass[i] = i; }
                });
            #endregion

            #region task7
            Shop.block = new BlockingCollection<string>(5);
            Task ShopWorkers = new Task(Shop.Adding);
            Task Clients = new Task(Shop.Selling);
            ShopWorkers.Start();
            Clients.Start();
            Clients.Wait();
            ShopWorkers.Wait();
            #endregion

            #region task8
            FactAsync(9);
            #endregion
            Thread.Sleep(1);
            Console.WriteLine("End of programm");
        }

        public static int factorial(int number)
        {
            int res = 1;
            for (int i = 2; i < number; i++)
                res *= i;
            return res;
        }

        static async void FactAsync(int number)
        {
            Console.WriteLine("FactAsync start"); // выполняется синхронно
            int result = await Task.Run(() => factorial(number));                // выполняется асинхронно
            Console.WriteLine($"Factorial of {number} = {result}. End of FactAsync");
        }
    }
}
