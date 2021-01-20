using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OOPLab12
{

    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Train))]
    [XmlInclude(typeof(ExpressTrain))]
    public class Transport : IntTransport
    {
        private int seats;
        public int Seats
        {
            get => seats;
            set => seats = value;
        }

        private double weight;
        public double Weight
        {
            get => weight;
            set => weight = value;
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        public Transport(int seats, double weight, string name)
        {
            this.seats = seats;
            this.weight = weight;
            this.name = name;
        }

        public Transport() { }
        public virtual void Info()
        {
            Console.WriteLine($"Transport {name} have a {seats} seats and a weight {weight} kg");
        }
        public override string ToString()
        {
            return $"Transport {name}, seats {seats}, weight {weight}";
        }
    }
}

