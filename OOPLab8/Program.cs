using System;
using System.IO;
using System.Xml.Serialization;

namespace OOPLab8
{
    class Program
    {      
        static void Main(string[] args)
        {
            try
            {
                //int a;
                //List<int> ints = new List<int>(new int[] { 1, 322, 541, 1, 33, 123, 66 });
                //abc.Print();
                //List<float> strings = new List<float>(4);

                //strings.Print();
                //Console.WriteLine(strings.Size);

                Car c = new Car(8, 1200, "volvo v60", 2015, 240);
                Train t = new Train(240, 60000, "Stadler", 1435);
                ExpressTrain et = new ExpressTrain(200, 45000, "Stadler", 1435, 13);
                List<Transport> transports = new List<Transport>(new Transport[] { t, c, c, t, t, c, c });
                transports.Pop();
                transports.Add(t);
                transports.Add(et);
                // transports.Print();
                List<Train> trains = new List<Train>(3);
                trains.Add(t);
                trains.Add(et);
                trains.Add(et);
                // List<Train> errs = new List<Train>(-1);
                transports.WriteXml("transports");
                //List<Car> cars = new List<Car>(new Car[] {
                //    new Car(5, 1200, "Volvo v60", 2015, 240),
                //    new Car(8, 1150, "Ford Focus", 2020, 220),
                //    new Car(6, 1400, "Tesla Model X", 2019, 310),
                //    new Car(9, 1550, "Mitsubishi Pajero", 2012, 230),
                //    new Car(6, 1350, "Vovlo xc90", 2020, 260),
                //    new Car(5, 1220, "Audi A6", 2014, 300),
                //    new Car(4, 1000, "Ferrari f40", 2018, 360)
                //});
                //cars.WriteXml("cars");
                List<Car> tr = new List<Car>("cars");
                tr.Print();
            }
            catch (IndexOutOfRangeException excp)
            {
                Console.WriteLine($"Index out of range: {excp.Message} at {excp.TargetSite}");
            }
            catch (ArgumentOutOfRangeException excp)
            {
                Console.WriteLine($"Argument out of range exception: {excp.Message} at {excp.TargetSite}");
            }
            catch (Exception excp)
            {
                Console.WriteLine($"Exception: {excp.Message} at {excp.TargetSite}");
            }
            finally
            {

            }
        }
    }
}
