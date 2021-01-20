using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab5
{
    class CarEngine : AbsEngine
    {
       public string Fuel
        {
            get => fuel_type;
            set => fuel_type = value;
        }
        public int Horse_power
        {
            get => horse_power;
            set => horse_power = value;
        }
        public double Consumption
        {
            get => consumption;
            set => consumption = value;
        }
        private double capacity;
        public double Capacity
        {
            get => capacity;
            set => capacity = value;
        }

        public CarEngine(string fuel_type = "petrol" , int horse_power = 100, double consumption = 6.2, double capacity = 1.8) : base(fuel_type, horse_power, consumption)
        {
            this.capacity = capacity;
        }
        public override void Info()
        {
            Console.WriteLine($"car engine fuel type is {Fuel}, capacity {Capacity}l, consumtion {Consumption} l/100 km and have {horse_power} horsepower");
        }

        public override string ToString()
        {
            return $"fuel type {fuel_type}, consumption {consumption} l/100km, capacity {capacity}l, horsepower {horse_power}";
        }
    }
}
