using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
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
        public Train(int price, string name, int track_width, int max_speed, TrainEngine engine, Carriage[] carriages) : base(CountSeats(carriages), price, name, max_speed)
        {
            if (track_width < 0) throw new WrongInputException("Invalid input when instantiating the class Train");
            this.carriages = carriages;
            this.track_width = track_width;
            this.engine = engine;
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
            Console.WriteLine($"Train {Name} with {carriages.Length} carriages, {Seats} overall seats, price {Price}$ have {track_width}mm track width");
        }

        public override string ToString()
        {
            return $"Train {Name}, seats {Seats}, price {Price}$, max speed {MaxSpeed}, carriages {carriages.Length}, track_width {track_width}mm, engine: {engine.ToString()}";
        }
    }
}
