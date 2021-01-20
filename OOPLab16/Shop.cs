using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace OOPLab16
{
    public static class Shop
    {
        public static BlockingCollection<string> block;
        public static void Adding()
        {
            Random r = new Random();
            int x;
            List<string> products = new List<string>() { "PC", "Fridge", "Lamp", "Kettle", "Oven" };
            for (int i = 0; i < 5; i++)
            {
                x = r.Next(0, products.Count - 1);
                Console.WriteLine("Added product: " + products[x]);
                block.Add(products[x]);
                products.RemoveAt(x);
                Thread.Sleep(r.Next(5, 10));
            }
            block.CompleteAdding();
        }
        public static void Selling()
        {
            Random r = new Random();
            string str;
            for(int i = 0; block.IsAddingCompleted == false && i < 10; i++)
            {
                if (block.TryTake(out str) == true)
                    Console.WriteLine("The item was purchased: " + str);
                else Console.WriteLine("The buyer is gone");
                Thread.Sleep(r.Next(2, 4));
            }
        }
    }
}
