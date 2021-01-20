using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace OOPLab8
{
    [Serializable]
    class List<T> : IList<T> where T : Transport
    {

        public List(int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException($"size (your value {size})");
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

        public List(string file_name)
        {
            string path = "C:\\Users\\dimde\\OneDrive\\Рабочий стол\\ООТП\\OOPLab8\\OOPLab8\\" + file_name + ".xml";

            XmlSerializer formatter = new XmlSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                data = (T[])formatter.Deserialize(fs);
                size = data.Length;
                current_size = size;
            }
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

        private T[] data;
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
        public List<T> Add(T value)
        {
            if (!(value is T)) throw new Exception("The type being added does not match the stored type");
            if (current_size < size)
            {
                data[current_size] = value;
            }
            else
            {
                T[] new_data = new T[size * 2];
                Array.Copy(data, 0, new_data, 0, size);
                data = new_data;
                data[size] = value;
                size *= 2;

            }
            current_size++;
            return this;
        }

        public List<T> Pop()
        {
            if (size <= 0 || current_size <= 0) throw new Exception("You cant pop from empty list");
            T[] new_data = new T[current_size - 1];
            Array.Copy(data, 0, new_data, 0, current_size - 1);
            data = new_data;
            current_size--;
            size--;

            return this;
        }

        public void Print()
        {
            Console.WriteLine($" \t------------ List Data -----------");
            for (int i = 0; i < current_size; i++)
                Console.WriteLine(data[i]);
            Console.WriteLine();
        }

        public T[] ToArray()
        {
            T[] new_data = new T[current_size];
            Array.Copy(data, 0, new_data, 0, current_size);
            return new_data;
        }

        public void WriteXml(string file_name = "transports")
        {
            string path = "C:\\Users\\dimde\\OneDrive\\Рабочий стол\\ООТП\\OOPLab8\\OOPLab8\\" + file_name + ".xml";
            XmlSerializer formatter = new XmlSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ToArray());
                Console.WriteLine($"Объект сериализован в файл {file_name}.xml");
            }
        }
    }
}
