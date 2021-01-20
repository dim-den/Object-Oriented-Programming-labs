using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace OOPLab10
{
    class Software<T> :    IList<T>
    {
        private T[] data;
        private Random rnd = new Random();
        private double version = 1.0;
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public double Version
        {
            get => version;
            set => version = value;
        }
        private int size;
        public int Size
        {
            get => size;
            set => size = value;
        }
        private int current_size;
        public int CurrentSize
        {
            get => current_size;
            set => current_size = value;
        }

        public Software(string name)
        {
            this.name = name;
            size = 1;
            data = new T[size];
            current_size = 0;
        }

        public Software(string name, int size)
        {
            this.name = name;
            if (size <= 0) throw new ArgumentOutOfRangeException($"size (your value {size})");
            data = new T[size];
            Size = size;
            current_size = 0;
        }

        public Software(string name, T[] values)
        {
            this.name = name;
            data = values;
            size = values.Length;
            current_size = size;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
           
        public void Add(T item)
        {
            if (current_size < size)
            {
                data[current_size] = item;
            }
            else
            {
                T[] new_data = new T[size * 2];
                Array.Copy(data, 0, new_data, 0, size);
                data = new_data;
                data[size] = item;
                size *= 2;

            }
            double v = rnd.Next(0, 4);
            v /= 10;
            version += v;
            current_size++;
        }

        public void Clear()
        {
            data = null;
            size = current_size = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < current_size; i++)
                if (data[i].Equals(item)) return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            for(int i = 0; i < current_size; i++)
            {
                if(data[i].Equals(item))
                {
                    for (int j = i; i < current_size - 1; i++)
                        data[j] = data[j + 1];
                    current_size--;
                    double v = rnd.Next(0, 2);
                    v /= 10;
                    version += v;
                    return true;
                }
            }
            return false;
        }

        public int Count
        {
            get => current_size;
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < current_size; i++)
                if (data[i].Equals(item)) return i;
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > current_size) return;
            if (current_size < size)
            {
                for(int i = current_size; i > index; i--)
                    data[i] = data[i - 1];
                data[index] = item;
            }
            else
            {
                T[] new_data = new T[size * 2];
                Array.Copy(data, 0, new_data, 0, size);
                data = new_data;
                size *= 2;
                for (int i = current_size; i > index; i--)
                    data[i] = data[i - 1];
                data[index] = item;
            }
            current_size++;
            double v = rnd.Next(0, 4);
            v /= 10;
            version += v;
        }

        public void RemoveAt(int index)
        {
            if (index > current_size || index < 0) return;
            double v = rnd.Next(0, 2);
            v /= 10;
            version -= v;
            if (index == current_size -1)
            {
                current_size--;
                return;
            }
            for (int i = index; i < current_size - 1; i++)
                data[i] = data[i + 1];
            current_size--;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0) throw new IndexOutOfRangeException("Index should be positive");
                if (index >= size) throw new IndexOutOfRangeException("Index out of List");
                return data[index];
            }
            set
            {
                if (index < 0) throw new IndexOutOfRangeException("Index should be positive");
                if (index >= size) throw new IndexOutOfRangeException("Index out of List");
                data[index] = value;
            }
        }

        public void Print()
        {
            Console.WriteLine($"Software {name} v{version} contains such features:");
            for (int i = 0; i < current_size; i++)
                Console.WriteLine(data[i]);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region task1
            Software<string> s = new Software<string>("Android");
            s.Add("Interface"); 
            s.Add("Buttons");
            s.Add("Online"); 
            s.Insert(s.IndexOf("Buttons"), "Optimization"); 
            s.Remove("Text editor"); 
            s.Add("Updates"); 
            s.RemoveAt(1); 
            s.Print();
            Console.WriteLine(s.Contains("Buttons"));
            Console.WriteLine(s.Contains("Optimization\n"));
            #endregion

            #region task2
            SortedList<char, int> sl = new SortedList<char, int>();
            sl.Add('a', 13);
            sl.Add('f', 44);
            sl.Add('h', 1);
            sl.Add('г', -33);
            sl.Add('б', 131);
            sl.Add('я', 1113);
            sl.Add('d', 3677);
            sl.Add('k', 228);

            foreach (var element in sl)
                Console.WriteLine(element);

            sl.Remove('б');
            sl.Remove('г');

            Console.WriteLine();
            foreach (var element in sl)
                Console.WriteLine(element);
            Console.WriteLine();

            Queue<int> que = new Queue<int>();
            foreach (var element in sl)
                que.Enqueue(element.Value);
            Console.WriteLine();

            foreach (var element in que)
                Console.Write($"{element} ");
            Console.WriteLine();
            Console.WriteLine(que.Contains(14));
            Console.WriteLine(que.Contains(44));
            Console.WriteLine();
            #endregion

            #region task3
          ObservableCollection<Software<string>> obs_coll = new ObservableCollection<Software<string>>();
            obs_coll.CollectionChanged += OnChange;
            Software<string> soft1 = new Software<string>("QWE", new string[4] { "1", "2", "3", "4" });
            Software<string> soft2 = new Software<string>("ABC", new string[6] { "a", "b", "c", "d", "e", "f" });
            Software<string> soft3 = new Software<string>("EFG", new string[2] { "123", "456" });
            obs_coll.Add(s);
            obs_coll.Add(soft1);
            obs_coll.Add(soft2);
            obs_coll.Add(soft3);
            obs_coll.Remove(soft2);
            obs_coll.RemoveAt(1);


            #endregion
        }
        public static void OnChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Software<string> added = e.NewItems[0] as Software<string>;
                    Console.WriteLine($"Added a new software with name {added.Name} and {added.Count} features");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Software<string> deleted = e.OldItems[0] as Software<string>;
                    Console.WriteLine($"Deleted software with name {deleted.Name} and {deleted.Count} features");
                    break;
            }
        }
      
    }
}
