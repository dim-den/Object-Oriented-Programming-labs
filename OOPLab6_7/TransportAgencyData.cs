using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class TransportAgencyData
    {
        private List<Transport> transports = new List<Transport>();

        public List<Transport> Transports { get => transports; }

        public void AddTransport(Object obj)
        {
            System.Diagnostics.Debug.Assert(obj != null, "Object should not be null") ;
            if(obj is Transport) transports.Add(obj as Transport);
            else throw new Exception("You can't add not a Transport object");
        }

        public void PrintTranports()
        {
            Console.WriteLine("Transport of agency:");
            for (int i = 0; i < transports.Count; i++)
            {
                Console.WriteLine(transports[i].ToString());
            }
        }

        public void GetTransport(int index)
        {
            if (index < 0 ) throw new WrongIndexException("Index should be positive", index);
            if (index >= transports.Count) throw new WrongIndexException("Index out of array", index, transports.Count);
            Console.WriteLine(transports[index].ToString());
        }

        public void DeleteTransport(int index)
        {
            if (index < 0) throw new WrongIndexException("Index should be positive", index);
            if (index >= transports.Count) throw new WrongIndexException("Index out of array", index, transports.Count);

            transports.RemoveAt(index);
            Console.WriteLine($"Элемент {index} удалён.\n");

        }
    }
}
