using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    partial class ExpressTrain
    {
        public override void Info()
        {
            Console.WriteLine($"Experess train {Name} with {Carriages.Length} carriages, {Seats} overall seats and ticket price {ticket_price} belarussian rubles");
        }
        public override string ToString()
        {
            return $"Express train {Name}, seats {Seats}, price {Price}$, max speed {MaxSpeed}km/h, carriages {Carriages.Length}, track_width {Track_width}mm, ticket price {ticket_price}, engine: {Engine.ToString()}";
        }
    }
}
