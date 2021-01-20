using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    interface IntCarriage
    {
        void Info();
    }

    abstract class AbsCarriage
    {
        public abstract void Info();
    }

    public enum SeatType
    {
        kype,
        lux,
        plackart,
        sitting
    }

    public struct CarriageData
    {
        public int seats;
        public SeatType seat_type;
    }
    sealed class Carriage : AbsCarriage, IntCarriage
    {
        private CarriageData carriage_data;
        public int Seats
        {
            get => carriage_data.seats;
            set => carriage_data.seats = value;
        }

        public string Seat_type
        {
            get
            {
                if (carriage_data.seat_type == SeatType.kype) return "kupe";
                else if (carriage_data.seat_type == SeatType.lux) return "lux";
                else if (carriage_data.seat_type == SeatType.plackart) return "plackart";
                else return "sitting";
            }
        }

        public Carriage(int seats = 60, SeatType seat_type = SeatType.sitting)
        {
            if ((carriage_data.seat_type != SeatType.kype && carriage_data.seat_type != SeatType.lux && carriage_data.seat_type == SeatType.plackart && carriage_data.seat_type == SeatType.sitting) || seats < 0)
                new WrongInputException("Invalid input when instantiating the class Carriage");
            this.Seats = seats;
            this.carriage_data.seat_type = seat_type;
        }
        void IntCarriage.Info()
        {
            Console.WriteLine($"Carriage have {Seats} seats");
        }
        public override void Info()
        {
            Console.WriteLine($"Carriage seat type is {carriage_data.seat_type}");
        }
        public override string ToString()
        {
            return $"carriage with {Seats} {Seat_type} seats";
        }
    }
}
