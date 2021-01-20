using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab12
{
    public class ExpressTrain : Train
    {
        private int ticket_price;
        public int Ticket
        {
            get => ticket_price;
            set => ticket_price = value;
        }
        public ExpressTrain() { }
        public ExpressTrain(int seats,double weight, string name, int track_width, int ticket_price) : base(seats,weight, name, track_width)
        {
            this.ticket_price = ticket_price;
        }
        public override void Info()
        {
            Console.WriteLine($"Experess train {Name} with {Seats} overall seats and ticket price {ticket_price} belarussian rubles");
        }
        public override string ToString()
        {
            return $"Express train {Name}, seats {Seats}, weight {Weight} tonns, track_width {Track_width}mm, ticket price {ticket_price}";
        }
    }
}
