using System;
using System.Text;

namespace OOPLab2
{
    class Program
    {
        static void Types()
        {            // 1. Типы 
            bool b = true;
            Console.Write("Bool: ");
            Console.WriteLine(b);

            byte by = 8;
            Console.Write("Byte: ");
            Console.WriteLine(by);

            sbyte sby = (sbyte)by; // явное 1
            Console.Write("Sbyte: ");
            Console.WriteLine(sby); 

            Console.Write("Input char: ");
            char ch = Convert.ToChar(Console.ReadLine());// явное 2
            Console.Write("Char: ");
            Console.WriteLine(ch); 

            decimal dcl = 133.7m;
            Console.Write("Decimal: ");
            Console.WriteLine(dcl);

            float fl = (float)dcl;// явное 3
            Console.Write("Float: ");
            Console.WriteLine(fl); 

            double db = fl; // неявное 1
            Console.Write("Double: ");
            Console.WriteLine(db);

            Console.Write("Input short: ");
            short s = Convert.ToInt16(Console.ReadLine()); // явное 4
            Console.Write("Short: ");
            Console.WriteLine(s); 

            ushort us = 64;
            Console.Write("Ushort: ");
            Console.WriteLine(us);

            int i = s;// неявное 2
            Console.Write("Int: ");
            Console.WriteLine(i); 

            uint ui = (uint)i;// явное 5
            Console.Write("Uint: ");
            Console.WriteLine(ui); 

            long l = i + 1231;  // неявное 3
            Console.Write("Long: ");
            Console.WriteLine(l); 
          
            ulong ul = 18446744073709551615;
            Console.Write("Ulong: ");
            Console.WriteLine(ul);

            l = s; // неявное 4
            ul = ui; // неявное 5

            object o = i; // упаковка 
            int j = (int)o; // распаковка

            for (var v = 5; v < 11; v++) { } // неявно типизированнная переменная 
                                             // Do something
            int? age = null; // Nullable переменная
            if (!age.HasValue) Console.WriteLine("Age have a null value");
            else
            {
                Console.Write("Age have a value = ");
                Console.WriteLine(age);
            }

            var variable = 54;
            //variable = "123";
        }

        static void Strings()
        {  //2. Строки
            string it = "Information technology", abc = "abcdef";
            var result = String.Compare(it, abc);
            if (result < 0) {
                Console.WriteLine("it < abc");
            }
            else if (result > 0) {
                Console.WriteLine("it > abc");
            }
            else {
                Console.WriteLine("it = abc");
            }

            string concat = it + " " + abc;
            Console.WriteLine(concat);
            string copy = concat;

            string substr = copy.Substring(0, 12);
            Console.WriteLine(substr);

            string[] words = copy.Split(' ');
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }

            string ins = "Apple ";
            copy = copy.Insert(12, ins);
            Console.WriteLine(copy);

            copy = copy.Remove(0, 12);
            Console.WriteLine(copy);

            // Интерполирование строк
            long number = 19876543210;
            Console.WriteLine($"{number:+# ### ### ## ##}");

            string empty;
            string null_str = null;

            if(String.IsNullOrEmpty(null_str))
            {
                Console.WriteLine("String is null or empty");        
            }
            string res = some_func(4);
            if (!String.IsNullOrEmpty(res))
            {
                Console.WriteLine(res);
            }

            //StringBuilder
            StringBuilder sb = new StringBuilder("C# / C++");
            sb.Remove(1,5);
            Console.WriteLine(sb);

            sb.Insert(0, "Python / ");
            Console.WriteLine(sb);

            sb.Append(" / C#");
            Console.WriteLine(sb);

        }

        static void Arrays()
        {
            int[,] mas = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            int rows = mas.GetUpperBound(0) + 1;
            int columns = mas.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(mas[i,j]); Console.Write('\t');
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            string[] str_arr = { "C#", "Java", "C++", "Python", "JavaScript", "Rust" };
            foreach (string element in str_arr)
            {
                Console.Write(element); Console.Write('\t');
            }
            Console.Write("\nLength of array = "); Console.WriteLine(str_arr.Length);
            Console.WriteLine("Input the position of the element you want to change and a new value");
            int pos = Convert.ToInt32(Console.ReadLine());
            str_arr[pos - 1] = Console.ReadLine();
            foreach (string element in str_arr)
            {
                Console.Write(element); Console.Write('\t');
            }

            // ступенчатый массив
            double[][] jagged_arr = new double[3][];
            jagged_arr[0] = new double[2];
            jagged_arr[1] = new double[3];
            jagged_arr[2] = new double[4];
            Console.WriteLine("\nInput array values");
            for(int i = 0;i < jagged_arr.Length; i++)
            {
                for(int j = 0; j < jagged_arr[i].Length;j++)
                {
                    jagged_arr[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            var v = new[] { true, false, true };
            var MI = new[,] { { 3, 5, -4 },
                  { 2, -1, 0 },
                  { 4, 9, 3 },
                  { -11, -5, 91 } };
            var str = "123213";
        }

        static void Tuples()
        {
            (int, string, char, string, ulong) tuple =(11, "note", 'g', "walk", 31223112);
            Console.WriteLine(tuple);
            Console.Write(tuple.Item1);
            Console.Write('\t');
            Console.Write(tuple.Item3);
            Console.Write('\t');
            Console.WriteLine(tuple.Item5);

           
            var (i, s1, c, s2, ul) = tuple; // распаковка
            //(int i, string s1, char c, string s2, ulong ul) = tuple;
            Console.WriteLine(s1);

            int age;
            string name;
            (age, _, _, name, _) = tuple; // пустые переменные
            (int y, int m, int d) date1 = (2020,8,9), date2 = (2020, 7, 11);
            if (date1 == date2) Console.WriteLine("Tuples are equal");
            else Console.WriteLine("Tuples are not equal");
        }
        static string some_func(int a)
        {
            if (a % 2 == 1) return null;
            return "Success run";
        }
        static void Main(string[] args)
        {
            Types();
            //Strings();
            //Arrays();
            //Tuples();

            (int max, int min, int sum, char fst_let) loc_func(int[] arr, string str)
            {
                int min = arr[0], max = arr[0], sum = 0;
                foreach (int element in arr)
                {
                    if (min > element) min = element;
                    if (max < element) max = element;
                    sum += element;
                }
                return (max, min, sum, str[0]);
            }

            void checked_func()
            {
                checked
                {
                    int max = Int32.MaxValue;
                }
            }

            void unchecked_func()
            {
                unchecked
                {
                    int max = Int32.MaxValue;
                }
            }

            Console.WriteLine(loc_func(new int[7]{ 1, 33 , 31 , 54, -11 , 99 , 7}, "abcd"));
            checked_func();
            unchecked_func();
        }
    }
}
