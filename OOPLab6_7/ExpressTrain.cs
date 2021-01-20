using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    partial class ExpressTrain : Train
    {
        private int ticket_price;
        public int Ticket
        {
            get => ticket_price;
            set => ticket_price = value;
        }
        public ExpressTrain(int price, string name, int track_width, int max_speed, TrainEngine engine, Carriage[] carriages, int ticket_price) : base(price, name, track_width, max_speed, engine, carriages)
        {
            this.ticket_price = ticket_price;
        }
    }
}
