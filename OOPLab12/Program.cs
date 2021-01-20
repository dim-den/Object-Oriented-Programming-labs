using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace OOPLab12
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"Assembly name of class System.Int32: {Reflector<int>.GetAssemblyName("System.Int32")}\n");

            Console.WriteLine($"Class Transport have public constructors: {Reflector<int>.HavePublicConstructors("OOPLab12.Transport")}\n");

            Console.WriteLine($"Class Car public methods: "); Print(Reflector<int>.GetPublicMethods("OOPLab12.Car")); Console.WriteLine();

            Console.WriteLine($"Class Train have such public properties and fields: "); Print(Reflector<int>.GetPropertiesFields("OOPLab12.Train")); Console.WriteLine();

            Reflector<int>.TypeMethods("System.String", "Int32"); Console.WriteLine();

            Reflector<int>.Invoke("OOPLab12.Car", "Drive");

        
            var train = Reflector<Train>.Create(new Train());

        }

        public static void Print(IEnumerable<string> list)
        {
            foreach (var element in list)
                Console.WriteLine(element);
        }
    }
}
