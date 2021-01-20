using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OOPLab14
{
    [Serializable, XmlRoot("Car")]

    public class Car : Transport
    {
        private int max_speed;
        public int Max_speed
        {
            get => max_speed;
            set => max_speed = value;
        }

        private int year;
        public int Year
        {
            get => year;
            set => year = value;
        }

        public Car() { }

        public Car(int seats, double weight, string name, int year, int max_speed) : base(seats, weight, name)
        {
            this.year = year;
            this.max_speed = max_speed;
            
        }

        public override void Info()
        {
            Console.WriteLine($"Car {Name} was produced in {year} and it's max speed {max_speed} km/h");
        }

        public override string ToString()
        {
            return $"Car {Name}, seats {Seats}, weight {Weight}, max speed {max_speed} , year {year}";
        }
    }
}
