using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab5
{
    class Train : Transport
    {

        private double track_width;
        public double Track_width
        {
            get => track_width;
            set => track_width = value;
        }

        private TrainEngine engine;

        public TrainEngine Engine
        {
            get => engine;
            set => engine = value;
        }

        private Carriage[] carriages;
        public Carriage[] Carriages
        {
            get => carriages;
            set => carriages = value;
        }
        public Train(double weight, string name, int track_width, TrainEngine engine, Carriage[] carriages) : base(CountSeats(carriages), weight, name)
        {
            this.carriages = carriages;
            this.track_width = track_width;
            this.engine = engine;
            this.carriages = carriages;
        }


        static public int CountSeats(Carriage[] carriages)
        {
            int seat_count = 0;
            foreach (Carriage carriage in carriages)
                seat_count += carriage.Seats;
            return seat_count;
        }
        public override void Info()
        {
            Console.WriteLine($"Train {Name} with {carriages.Length} carriages, {Seats} overall seats and with total weight {Weight} tons have {track_width}mm track width");
        }

        public override string ToString()
        {
            return $"Train {Name}, seats {Seats}, weight {Weight} tonns, carriages {carriages.Length}, track_width {track_width}mm, engine: {engine.ToString()}";
        }
    }
}
