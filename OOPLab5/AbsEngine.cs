using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab5
{
    abstract class AbsEngine
    {
        protected string fuel_type;
        protected int horse_power;
        protected double consumption;
        public abstract void Info();
        public AbsEngine(string fuel_type, int horse_power, double consumption)
        {
            this.fuel_type = fuel_type;
            this.horse_power = horse_power;
            this.consumption = consumption;
        }
    }
}
