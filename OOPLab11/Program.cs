using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region task1
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int length = 8;
            var months_by_length = from t in months
                                   where t.Length == length
                                   select t;

            Console.WriteLine("Only months with lenght {0}:", length);
            foreach (var element in months_by_length)
                Console.WriteLine(element);
            string[] sum_win_months = { "December", "January", "February", "June", "July", "August" };
            Console.WriteLine();

            var only_win_sum_months = from t in months
                                      where sum_win_months.Contains(t)
                                      select t;
            Console.WriteLine("Only summer and winter months:");
            foreach (var element in only_win_sum_months)
                Console.WriteLine(element);
            Console.WriteLine();

            var sorted_months = from t in months
                                orderby t
                                select t;
            Console.WriteLine("Sorted months:");
            foreach (var element in sorted_months)
                Console.WriteLine(element);
            Console.WriteLine();

            int count_some_months = (from t in months
                                     where t.Length >= 4 && t.Contains('u')
                                     select t).Count();
            Console.WriteLine($"Months that have letter 'u' and lentgh more or equal than 4 = {count_some_months}");
            Console.WriteLine();
            #endregion

            #region task2/3/5
            List<Train> trains = new List<Train>();
            trains.Add(new Train(2, "Minsk", 4, 12, new train_seats(11, 3, 11, 55)));
            trains.Add(new Train(4, "Moscow", 8, 23, new train_seats(123, 22, 9, 15)));
            trains.Add(new Train(8, "Minsk", 12, 34, new train_seats(27, 69, 19, 6)));
            trains.Add(new Train(16, "Brest", 16, 45, new train_seats(88, 41, 8, 159)));
            trains.Add(new Train(12, "Minsk", 16, 14, new train_seats(25, 19, 49, 65)));
            trains.Add(new Train(55, "Warsawa", 21, 47, new train_seats(28, 10, 64, 9)));
            trains.Add(new Train(27, "Grodno", 19, 47, new train_seats(22, 11, 34, 15)));
            trains.Add(new Train(54, "Vilnus", 22, 10, new train_seats(27, 54, 9, 29)));

            string destination = "Minsk";
            var trains_destiny = trains.Where(t => t.destination == destination);
            Console.WriteLine("Trains that going to {0}:", destination);
            foreach (var element in trains_destiny)
                Console.WriteLine(element);
            Console.WriteLine();

            int hour = 13;
            var trains_destiny_time = trains.Where(t => t.destination == destination && t.hour > hour);
            Console.WriteLine($"Trains that going to {destination} after {hour - 1}:59", destination, hour); ;
            foreach (var element in trains_destiny_time)
                Console.WriteLine(element);
            Console.WriteLine();

            var train_max_seats = (from t in trains
                                   orderby t.SeatCount
                                   select t).Last();
            Console.WriteLine("Train with largest amount of seats:");
            Console.WriteLine(train_max_seats);
            Console.WriteLine();

            var train_latest_arrival = (from t in trains
                                        orderby t.minute
                                        orderby t.hour
                                        select t).TakeLast(5);
            Console.WriteLine("TOP-5 trains with latest arrival time:");
            foreach (var element in train_latest_arrival)
                Console.WriteLine(element);
            Console.WriteLine();

            var trains_sorted = from t in trains
                                orderby t.destination
                                select t;
            Console.WriteLine("Sorted trains by destination:");
            foreach (var element in trains_sorted)
                Console.WriteLine(element);
            Console.WriteLine();

            var seats = trains.Where(t => t.destination == "Minsk").OrderBy(t => t.hour).Take(2).Sum(t => t.SeatCount);
            Console.WriteLine(seats);
            #endregion

            #region task5
            var customers = new []{ new { ID = 1, Name = "Abc" }, new { ID = 2, Name = "Def" }, new { ID = 3, Name = "Qwe" } };
            var purchases = new[] { new { CustomerID = 1, Product = "house" }, new { CustomerID = 3, Product = "car" }, new { CustomerID = 2, Product = "phone" } };
          
            var query =
                from c in customers
                join p in purchases on c.ID equals p.CustomerID
                select c.Name + " bought a " + p.Product;

            Console.WriteLine("Result of join: ");
            foreach (var element in query)
                Console.WriteLine(element);
            #endregion
        }
    }
}
