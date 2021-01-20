using System;

namespace OOPLab4
{

    class List<T>
    {
 
        public List(int size)
        {
            data = new T[size];
            Size = size;
            current_size = 0;
        }
        public List(T[] values)
        {
            data = values;
            size = values.Length;
            current_size = size;
        }
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        private T[] data;
        private int size;
        private int current_size;
        public List<T> Add(T value)
        {
            if(current_size < size)
            {
                data[current_size] = value;
            }
            else
            {
                T[] new_data = new T[size + 1];
                Array.Copy(data, 0, new_data, 0, size);
                data = new_data;
                data[size] = value;
                size++;
              
            }
            current_size++;
            return this;
        }

        public List<T> Pop()
        {
            if(current_size < size)
            {
                size--;
            }
            else
            {
                T[] new_data = new T[size-1];
                Array.Copy(data, 0, new_data, 0, size-1);
                data = new_data;
                size--;
            }
            return this;
        }

       public static List<T> operator + (List<T> list, T value) =>  list.Add(value);

        public static List<T> operator --(List<T> list) => list.Pop();

        public static bool operator ==(List<T> l1, List<T> l2)
        {
            if (l1.data == l2.data) return true;
            return false;
        }

        public static bool operator !=(List<T> l1, List<T> l2)
        {
            if (l1.data == l2.data) return false;
            return true;
        }

        public static bool operator true(List<T> list)
        {
            for(int i  =0; i < list.current_size - 1; i++)
            {
                dynamic a = list.data[i], b = list.data[i+1];
               
                if (a>b) return false;
            }
            return true;
        }
        public static bool operator false(List<T> list)
        {
            for (int i = 0; i < list.current_size - 1; i++)
            {
                dynamic a = list.data[i], b = list.data[i + 1];

                if (a > b) return true;
            }
            return false;
        }
        public int Size
        {
            get => size;
            set => size = value;
        }

        public class Owner
        {
            private int id;
            private string name;
            private string organisation;

            public Owner(int id, string name, string organisation)
            {
                this.id = id;
                this.name = name;
                this.organisation = organisation;
            }

            public int ID
            {
                get => id;
            }

            public string Name
            {
                get => name;
            }
            public string Organisation
            {
                get => organisation;
            }
        }

        public class Date
        {
            private int day, month, year;
            public int Day
            {
                get => day;
            }
            public int Month
            {
                get => month;
            }
            public int Year
            {
                get => year;
            }
            public   Date(int d, int m, int y)
            {
                day = d; month = m; year = y;
            }
            public Date(DateTime dt)
            {
                day = dt.Day;
                month = dt.Month;
                year = dt.Year;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> l1 = new List<int>(2);
            List<int> l2 = new List<int> (new int[4]{ 1,5,3,54});

            if (l2) Console.WriteLine("Sorted");
            else Console.WriteLine("Not sorted");
            l2 = l2 + 5;
            l2 = l2 + 33;
            l2--;
            Console.WriteLine(l1 == l2);
            var c = l2;
            Console.WriteLine(l2 == c);     
           for(int i = 0; i < l2.Size; i++)
            {
                Console.Write($" {l2[i]}");
            }
            List<int>.Owner owner = new List<int>.Owner(228, "Dmitriy Den", "BSTU");
            Console.WriteLine($"\nВладелец: ID: {owner.ID}, имя: {owner.Name}, " +
                $"организация: {owner.Organisation}");

            List<int>.Date date = new List<int>.Date(DateTime.Today);

            Console.WriteLine($"Дата создания: {date.Day}.{date.Month}.{date.Year}");

            Console.WriteLine($"Sum of elements: {StatisticOperation.Sum(l2)} ");

            Console.WriteLine($"Difference betweent max and min element: {StatisticOperation.DifferenceMaxMin(l2)} ");

            Console.WriteLine($"Size of list: {StatisticOperation.CountElements(l2)} ");

            string line = "Some words where generated by me";
            Console.WriteLine($"Words in line '{line}' : {StatisticOperation.CountWords(line)}");

            l2 = l2 + 0; l2 = l2 + 0;
            Console.WriteLine($"Zeros in list: {StatisticOperation.CountZeros(l2)}");
        }
    }
}
