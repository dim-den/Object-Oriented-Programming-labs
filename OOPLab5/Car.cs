using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab5
{
    class Car : Transport
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

        CarEngine engine;

        public CarEngine CarEngine
        {
            get => engine;
            set => engine = value;
        }

     
        public Car(int seats, double weight, string name, int year, int max_speed, CarEngine engine) : base(seats,weight,name)
        {
            this.year = year;
            this.max_speed = max_speed;
            this.engine = engine;
        }

        public override void Info()
        {
            Console.WriteLine($"Car {Name} was produced in {year} and it's max speed {max_speed} km/h");
        }

        public override string ToString()
        {
            return $"Car {Name}, seats {Seats}, weight {Weight}, max speed {max_speed} , year {year}, engine: {engine.ToString()}";
        }   
    }
}
