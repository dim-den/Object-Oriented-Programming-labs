using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class TrainEngine : AbsEngine
    {
        public string Fuel
        {
            get => fuel_type;
            set => fuel_type = value;
        }
        public double Consumption
        {
            get => consumption;
            set => consumption = value;
        }
        public int Horse_power
        {
            get => horse_power;
            set => horse_power = value;
        }

        public int weight;
        public int Weight
        {
            get => weight;
            set => weight = value;
        }
        public TrainEngine(string fuel_type = "diesel", int horse_power = 3000, double consumption = 600, int weight = 1200) : base(fuel_type, horse_power, consumption)
        {
            if (weight <= 0) throw new WrongInputException("Invalid input when instantiating the class TrainEngine");
            this.weight = weight;
        }
        public override void Info()
        {
            Console.WriteLine($"Train engine fuel type is {Fuel}, weight {weight},consumtion {Consumption} l/100 km and have {horse_power} horsepower");
        }
        public override string ToString()
        {
            return $"fuel type {fuel_type}, consumption {consumption} l/100km, weight {weight}kg, horsepower {horse_power}";
        }
    }
}
