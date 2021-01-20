using System;
using System.Diagnostics;

namespace OOPLab6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Lab_6
                Random rnd = new Random();

                CarEngine car_engine = new CarEngine("petrol", 228, 7, 2.2);
                Car car = new Car(5, 20000 + 1000 * rnd.Next(-10, 30), "Volvo v60", 2015, 220, car_engine);


                Carriage[] carriages1 = new Carriage[4] { new Carriage(44, SeatType.sitting), new Carriage(36, SeatType.kype), new Carriage(28, SeatType.kype), new Carriage(48, SeatType.sitting) };
                TrainEngine train_engine = new TrainEngine("diesel", 5000 + rnd.Next(-10, 10) * 100, 130 + rnd.Next(-30, 30), 800 + 10 * rnd.Next(-10, 10));


                TransportAgencyControl agencyControl = new TransportAgencyControl();

                for (int i = 0; i < 5; i++)
                {
                    agencyControl.AddTransport(new Car(5 + 3 * (i % 2), 1200 + 100 * i, "Volvo v" + Convert.ToString(30 + i * 10), 2005 + i, 200 + 10 * rnd.Next(-5, 10), new CarEngine("petrol", 200 + 15 * i, 5 + 0.1 * rnd.Next(-10, 10), 1.8 + 0.1 * i)));
                    agencyControl.AddTransport(new Train(500000 + 100000 * rnd.Next(-1, 5), "Ласточка", 1435 + 5 * rnd.Next(-10, 10), 260 + 10 * rnd.Next(-5, 15), train_engine, carriages1));
                }

                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"Transport agency transport overall price {agencyControl.TransportPrice()}$");
                Console.WriteLine("--------------------------------------------------------------------");
                agencyControl.PrintTranports();
                Console.WriteLine("--------------------------------------------------------------------");
                agencyControl.SortAutoByConsumption();
                Console.WriteLine("--------------------------------------------------------------------");
                var result = agencyControl.FindBySpeed(220, 230);
                if (result is null)
                {
                    Console.WriteLine("There is no transport with max speed between min and max");
                }
                else
                {
                    Console.WriteLine("Transport with max speed between min and max:");
                    Console.WriteLine(result.ToString());
                }
                #endregion

                Console.WriteLine("\n--------------------------------------------------------------------\n");

                #region Lab_7

                agencyControl.FindBySpeed(220, 210);    // WrongRangeException
                // agencyControl.GetTransport(50);         // WrongIndexException
                //CarEngine error_car_engine = new CarEngine("petrol", -5, 7, 2.2);   // WrongInputException
                //Car error_car = new Car(10, 20000 * 1000 * rnd.Next(-10, 30), "", 2015, 220, car_engine);   // WrongInputException
                //agencyControl.AddTransport(car_engine); // Wrong object type
                //int a = 0,ia = 1 / a;                   // Divide by zero
                #endregion
            }       
            catch (WrongRangeException excp)
            {
                Console.WriteLine($"WrongRangeException: {excp.Message} (max {excp.Max}, min {excp.Min}) at {excp.TargetSite}");
            }
            catch (WrongIndexException excp)
            {
                if(excp.Max != -1) Console.WriteLine($"WrongIndexException: {excp.Message} (index {excp.Value}, max index {excp.Max}) at {excp.TargetSite}");
                else Console.WriteLine($"WrongIndexException: {excp.Message} (index {excp.Value}) at {excp.TargetSite}");
            }
            catch(WrongInputException excp)
            {
                Console.WriteLine($"WrongInputException: {excp.Message} at {excp.TargetSite}");
            }
            catch(Exception excp)
            {
                Console.WriteLine($"Exception: {excp.Message} at {excp.TargetSite}");
            }
            catch 
            {
                Console.WriteLine("An unexpected error occurred");
            }
            finally
            {
                int[] aa = null;
                TransportAgencyControl agencyControl = new TransportAgencyControl();
               //  agencyControl.AddTransport(aa);  // Assert
            }
        }
    }
}
