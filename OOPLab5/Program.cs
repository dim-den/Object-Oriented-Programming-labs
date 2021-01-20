using System;

namespace OOPLab5
{
    class Program
    {
        static void Main(string[] args)
        {

            #region task_5
            CarEngine car_engine = new CarEngine("petrol", 228, 7, 2.2);
            Car car = new Car(5, 1222, "Volvo v60", 2015, 220, car_engine);
            car.Info();

            if (car is Transport) Console.WriteLine("Объект car принадлежит классу Transport.\n");            
            else Console.WriteLine("Объект car не принадлежит классу Transport.\n");

            Carriage[] carriages1 = new Carriage[4] { new Carriage(44, "sitting"), new Carriage(36, "kype"), new Carriage(28, "kype"), new Carriage(48, "sitting") };
            carriages1[0].Info();
            ((IntCarriage)carriages1[0]).Info();
            TrainEngine train_engine = new TrainEngine("diesel", 5321, 137, 780);
            Train train = new Train(77, "Ласточка", 1435, train_engine, carriages1);
            train.Info();

            if (train is Transport) Console.WriteLine("Объект train принадлежит классу Transport.\n");
            else Console.WriteLine("Объект train не принадлежит классу Transport.\n");

            Carriage[] carriages2 = new Carriage[5] { new Carriage(55, "sitting"), new Carriage(33, "kype"), new Carriage(28, "lux"), new Carriage(28, "plackart"), new Carriage(55, "sitting") };
            ExpressTrain expr_train = new ExpressTrain(40, "Stadler", 1435, train_engine, carriages2, 12);
            expr_train.Info();
            if (expr_train is Train) Console.WriteLine("Объект expr_train принадлежит классу Train.\n");
            else Console.WriteLine("Объект expr_train не принадлежит классу Train.\n");

            Transport train_copy = train as Transport;
            Console.WriteLine(train_copy.ToString());
            #endregion

            #region task_6
            Car c = new Car(8, 1200, "BMW M6", 2018, 320, new CarEngine("petrol", 320, 8, 3.2));
            Train t = new Train(66, "Стриж", 1435, train_engine, carriages1);
            ExpressTrain et = new ExpressTrain(33, "Stadler", 1335, train_engine, carriages2, 12);
            Printer printer = new Printer();
            Transport[] transports = new Transport[] { c, t, et };
            Console.WriteLine();
            foreach( var item in transports)
            {
                printer.IAmPrinting(item);
                Console.WriteLine();
            }
            #endregion

        }
    }
}
