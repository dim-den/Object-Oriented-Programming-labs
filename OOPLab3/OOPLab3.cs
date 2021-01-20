using System;

namespace OOPLab3
{
    public struct train_seats
    {
        public int common;
        public int kype;
        public int plackart;
        public int lux;
        public train_seats(int c = 0, int k = 0, int p = 0, int l = 0)
        {
            common = c; kype = k;
            plackart = p; lux = l;
        }
    }
    public partial class Train
    {

        private const int maxSeats = 1000;
        private readonly int ID;

        private int hour_;

        public int hour
        {
            get
            {
                return hour_;
            }
            private set
            {
                if (value > 24 || value < 0) Console.WriteLine("Wrong hour");
                else hour_ = value;
            }
        }
        private int minute_;
        public int minute
        {
            get
            {
                return minute_;
            }
            set
            {
                if (value > 59 || value < 0) Console.WriteLine("Wrong minute");
                else minute_ = value;
            }
        }
        static Train()
        {
            obj_count = 0;
        }
        public Train()
        {
            seats = new train_seats();
            train_number = obj_count;
            ID = GetHashCode();
            obj_count++;
        }
        public Train(train_seats ts, int tn, string d = "Moscow")
        {
            destiny = d;
            train_number = tn;
            seats = ts;
            obj_count++;
            ID = GetHashCode();
        }
        public Train(int tn, string d, int h, int m, train_seats ts)
        {
            destiny = d;
            train_number = tn;
            seats = ts;
            hour = h;
            minute = m;
            obj_count++;
            ID = GetHashCode();
        }
        private string destiny_;
        public string destiny
        {
            get
            {
                return destiny_;
            }
            set
            {
                if (value == null || value == "") Console.WriteLine("Wrong destiny");
                destiny_ = value;
            }
        }
        private int train_number_;
        public int train_number
        {
            get
            {
                return train_number_;
            }
            set
            {
                if (value < 0) Console.WriteLine("Train number have to be a positive");
                else train_number_ = value;
            }
        }
        private train_seats seats_;
        public train_seats seats
        {
            get
            {
                return seats_;
            }
            set
            {
                if (value.common < 0 || value.kype < 0 || value.lux < 0 || value.plackart < 0) Console.WriteLine("Wrong seats count");
                if (value.common + value.kype + value.lux + value.plackart > maxSeats) Console.WriteLine("Too many seats");
                else seats_ = value;
            }
        }

        private Train(int tn)
        {
            train_number = tn;
            destiny = "Minsk";
        }
        public int seats_count()
        {
            return seats.common + seats.kype + seats.plackart + seats.lux;
        }
        public bool is_equal_destiny(ref string dest)
        {
            if (String.Compare(destiny, dest) == 0) return true;
            return false;
        }
        public void destiny_time(ref string d, ref int h, out bool res)
        {
            if (is_equal_destiny(ref d) && hour > h)
            {
                res = true;
            }
            else res = false;
        }

        public void Print()
        {
            Console.WriteLine($"Поезд №{train_number}, пункт назаначения: {destiny}, время отправления: {hour}:{minute}, места: общих - {seats.common}, купе - {seats.kype}, плацкарт - {seats.plackart}, люкс - {seats.lux}");
        }
        public static void Info()
        {
            Console.WriteLine("Содержит информацию:  Пункт назначения, Номер поезда, Время отправления, Число мест (общих, купе, плацкарт, люкс)");
            Console.Write("Объектов Train всего создано: "); Console.WriteLine(obj_count);

        }
        public static int obj_count;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Train tr1 = new Train();
            Train tr2 = new Train(new train_seats(11, 3, 11, 55), 228, "Berlin");
            Train tr3 = new Train(2, "Minsk", 4, 12, new train_seats(11, 3, 11, 55));
            Train tr3_copy = tr3;
            Console.WriteLine($"Tr3 hash code: {tr3.GetHashCode()}");
            Train.Info();
            Console.WriteLine($"tr2 equal to tr3: {tr2.Equals(tr3)}");
            Console.WriteLine($"tr3 equal to tr3_copy: { tr3.Equals(tr3_copy)}");
            Console.WriteLine(tr3.ToString());
            Train[] trains = new Train[6]
            {
                new Train(2, "Minsk", 4, 12, new train_seats(11, 3, 11, 55)),
                new Train(4, "Moscow", 8,23, new train_seats(123, 22, 9, 15)),
                new Train(8, "Minsk", 12, 34, new train_seats(27, 69, 19, 6)),
                new Train(16, "Brest", 16, 45, new train_seats(88, 41, 8, 159)),
                new Train(8, "Minsk", 16, 14, new train_seats(25, 19, 49, 65)),
                new Train(16, "Warsawa", 11, 35, new train_seats(28, 10,  64, 9))
            };
            Console.WriteLine("Input a string destination and integer an hour");
            string dest = Console.ReadLine();
            int hour = Convert.ToInt32(Console.ReadLine());

            bool suc = false;
            foreach (var train in trains)
            {
                bool res;
                train.destiny_time(ref dest, ref hour, out res);
                if (res)
                {
                    if (!suc)
                    {
                        Console.WriteLine($"Trains arriving to {dest} after {hour}.59 :");
                        suc = true;
                    }
                    train.Print();
                }
            }
            if (!suc) Console.WriteLine($"There is no train in database arriving to {dest} after {hour}.59");

            var anonymous = new { train_number = 2, destiny = "Minsk", hour = 4, minutes = 12, seats = new train_seats(11, 3, 11, 55) };
        }
    }
}
