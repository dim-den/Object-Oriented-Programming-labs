using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class TransportAgencyControl : TransportAgencyData
    {
        public int TransportPrice()
        {
            int sum = 0;
            foreach (var transport in Transports)
                sum += transport.Price;
            return sum;
        }
        public void SortAutoByConsumption()
        {
            List<Car> cars = new List<Car>();
            foreach (var transport in Transports)
            {
                if (transport is Car) cars.Add(transport as Car);
            }

            cars.Sort(delegate (Car car1, Car car2)
            { return car1.Engine.Consumption.CompareTo(car2.Engine.Consumption); });

            foreach (Car transport in cars)
            {
                Console.WriteLine($"Car name: {transport.Name}, consumption: {transport.Engine.Consumption}");
            }
        }

        public Transport FindBySpeed(int min, int max)
        {
            if (min > max) throw new WrongRangeException("Max speed should be greater than min", min , max);

            foreach (var transport in Transports)
            {
                if (transport.MaxSpeed <= max && transport.MaxSpeed >= min)
                {
                    return transport;
                }
            }
            return null;

        }
    };



}
