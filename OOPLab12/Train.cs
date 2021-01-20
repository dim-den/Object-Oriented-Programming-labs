using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab12
{

    public class Train : Transport
    {

        public double track_width;
        public double Track_width
        {
            get => track_width;
            set => track_width = value;
        }

        public Train() { }
        public Train(int seats, double weight, string name, int track_width) : base(seats, weight, name)
        {
            this.track_width = track_width;    
        }
         
        public override void Info()
        {
            Console.WriteLine($"Train {Name} with  {Seats} overall seats and with total weight {Weight} tons have {track_width}mm track width");
        }

        public override string ToString()
        {
            return $"Train {Name}, seats {Seats}, weight {Weight} tonns, track_width {track_width}mm";
        }
    }
}
