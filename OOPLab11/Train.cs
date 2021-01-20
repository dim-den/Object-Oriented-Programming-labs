using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab11
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
    public class Train
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
            destination = d;
            train_number = tn;
            seats = ts;
            obj_count++;
            ID = GetHashCode();
        }
        public Train(int tn, string d, int h, int m, train_seats ts)
        {
            destination = d;
            train_number = tn;
            seats = ts;
            hour = h;
            minute = m;
            obj_count++;
            ID = GetHashCode();
        }
        private string destination_;
        public string destination
        {
            get
            {
                return destination_;
            }
            set
            {
                if (value == null || value == "") Console.WriteLine("Wrong destination");
                destination_ = value;
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
            destination = "Minsk";
        }
        public int seats_count()
        {
            return seats.common + seats.kype + seats.plackart + seats.lux;
        }
        public bool is_equal_destination(ref string dest)
        {
            if (String.Compare(destination, dest) == 0) return true;
            return false;
        }
        public void destination_time(ref string d, ref int h, out bool res)
        {
            if (is_equal_destination(ref d) && hour > h)
            {
                res = true;
            }
            else res = false;
        }
        public int SeatCount
        {
            get => seats_count();
        }
        
        public void Print()
        {
            Console.WriteLine($"Поезд №{train_number}, пункт назаначения: {destination}, время отправления: {hour}:{minute}, места: общих - {seats.common}, купе - {seats.kype}, плацкарт - {seats.plackart}, люкс - {seats.lux}");
        }
        public static void Info()
        {
            Console.WriteLine("Содержит информацию:  Пункт назначения, Номер поезда, Время отправления, Число мест (общих, купе, плацкарт, люкс)");
            Console.Write("Объектов Train всего создано: "); Console.WriteLine(obj_count);

        }
        public static int obj_count;

        public override string ToString()
        {
            return ($"Train number: {train_number}, destination: {destination}, arrive: {hour}:{minute}, seats: {seats_count()}");
        }
        public override bool Equals(object tr2)
        {
            if (tr2 == null) return false;
            Train t = tr2 as Train;
            if (t as Train == null) return false;
            return t.destination == destination && t.train_number == train_number && t.hour == hour && t.minute == minute
                && t.seats.common == seats.common && t.seats.kype == seats.kype && t.seats.plackart == seats.plackart && t.seats.lux == seats.lux;
        }

        public override int GetHashCode()
        {
            if (destination == null) return seats.GetHashCode() * 22 + 44 * hour + 31 * minute + 5 * train_number;
            return seats.GetHashCode() * 13 + 4 * destination.GetHashCode() + 44 * hour + 31 * minute + 5 * train_number;
        }
    }

}
