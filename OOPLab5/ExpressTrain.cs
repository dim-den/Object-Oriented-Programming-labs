using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab5
{
    class ExpressTrain : Train
    {
        private int ticket_price;
        public int Ticket
        {
            get => ticket_price;
            set => ticket_price = value;
        }
        public ExpressTrain(double weight, string name, int track_width, TrainEngine engine, Carriage[] carriages, int ticket_price) : base( weight, name, track_width, engine, carriages)
        {
            this.ticket_price = ticket_price;
        }
        public override void Info()
        {
            Console.WriteLine($"Experess train {Name} with {Carriages.Length} carriages, {Seats} overall seats and ticket price {ticket_price} belarussian rubles");
        }
        public override string ToString()
        {
            return $"Express train {Name}, seats {Seats}, weight {Weight} tonns, carriages {Carriages.Length}, track_width {Track_width}mm, ticket price {ticket_price}, engine: {Engine.ToString()}";
        }
    }
}
