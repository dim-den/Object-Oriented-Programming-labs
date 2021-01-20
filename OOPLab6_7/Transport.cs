using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class Transport : IntTransport
    {
        private int seats;
        public int Seats
        {
            get => seats;
            set => seats = value;
        }

        private int price;
        public int Price
        {
            get => price;
            set => price = value;
        }

        private int max_speed;
        public int MaxSpeed
        {
            get => max_speed;
            set => max_speed = value;
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        public Transport(int seats, int price, string name, int max_speed)
        {
            if (seats < 0 || price < 0 || name == "" || max_speed < 0) throw new WrongInputException("Invalid input when instantiating the class Transport");
            this.seats = seats;
            this.price = price;
            this.name = name;
            this.max_speed = max_speed;
        }
        public virtual void Info()
        {
            Console.WriteLine($"Transport {name} have a {seats} seats and price {price}$");
        }
        public override string ToString()
        {
            return $"Transport {name}, seats {seats}, price {price}";
        }
    }
}
