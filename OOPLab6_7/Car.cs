using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class Car : Transport
    {
        private int year;
        public int Year
        {
            get => year;
            set => year = value;
        }

        CarEngine engine;
        public CarEngine Engine
        {
            get => engine;
            set => engine = value;
        }

        public CarEngine CarEngine
        {
            get => engine;
            set => engine = value;
        }


        public Car(int seats, int price, string name, int year, int max_speed, CarEngine engine) : base(seats, price, name, max_speed)
        {
            if (year < 0) throw new WrongInputException("Invalid input when instantiating the class Car");
            this.year = year;
            this.engine = engine;
        }

        public override void Info()
        {
            Console.WriteLine($"Car {Name} was produced in {year} and it's max speed {MaxSpeed} km/h");
        }

        public override string ToString()
        {
            return $"Car {Name}, seats {Seats}, price {Price}$, max speed {MaxSpeed} , year {year}, engine: {engine.ToString()}";
        }
    }
}
