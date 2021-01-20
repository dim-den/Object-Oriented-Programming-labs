using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab5
{
    interface IntCarriage
    {
        void Info();
    }

    abstract class AbsCarriage
    {
        public abstract void Info();
    }
    sealed class Carriage : AbsCarriage, IntCarriage
    {

        private int seats;
        public int Seats
        {
            get => seats;
            set => value = seats;
        }
        private string seat_type;
        public string Seat_type
        {
            get => seat_type;
            set => value = seat_type;
        }

        public Carriage(int seats = 60, string seat_type = "sitting")
        {
            this.seats = seats;
            this.seat_type = seat_type;
        }
        void IntCarriage.Info()
        {
            Console.WriteLine($"Carriage have {seats} seats");
        }
        public override void Info()
        {
            Console.WriteLine($"Carriage seat type is {seat_type}");
        }
        public override string ToString()
        {
            return $"carriage with {seats} {seat_type} seats";
        }

        public override int GetHashCode()
        {
            return seats * 122 + seat_type.GetHashCode() * 5;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Carriage)) return false;
            if (obj as Carriage == null) return false;
            return obj as Carriage == this;
        }
    }
}
