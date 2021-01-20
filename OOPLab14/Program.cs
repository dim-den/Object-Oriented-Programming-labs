using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using System.Xml.Linq;
using System.Linq;


namespace OOPLab14
{
    class Program

    {
        static void Main(string[] args)
        {
            Car c = new Car(8, 1200, "volvo v60", 2015, 240);
            Train t = new Train(240, 60000, "Stadler", 1435);
            ExpressTrain et = new ExpressTrain(200, 45000, "Siak", 1435, 13);
            Transport[] transports = new Transport[] { c, t, et };
            BinaryFormatter binary = new BinaryFormatter();

            using (FileStream fs = new FileStream("car.dat", FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, c);
            }
          
            using (FileStream fs = new FileStream("car.dat", FileMode.OpenOrCreate))
            {
                Car newCar = (Car)binary.Deserialize(fs);
                Console.WriteLine(newCar);
            }

            Console.WriteLine("\n--------------------------------------------------------------------------------\n");

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Train));

            using (FileStream fs = new FileStream("train.json", FileMode.OpenOrCreate))
            {
                json.WriteObject(fs, t);
            }

            using (FileStream fs = new FileStream("train.json", FileMode.OpenOrCreate))
            { 
                var newTrain = ((Train)json.ReadObject(fs));
                Console.WriteLine(newTrain);
            }

            Console.WriteLine("\n--------------------------------------------------------------------------------\n");

            XmlSerializer xml = new XmlSerializer(typeof(Transport[]));

            using (FileStream fs = new FileStream("transports.xml", FileMode.Truncate))
            {
                
                xml.Serialize(fs, transports);
            }
            using (FileStream fs = new FileStream("transports.xml", FileMode.OpenOrCreate))
            {
                var newTransports = (Transport[])xml.Deserialize(fs);
                foreach (var el in newTransports)
                    Console.WriteLine(el);
            }

            Console.WriteLine("\n--------------------------------------------------------------------------------\n");
          
            var cars = new Transport[30];
            var rnd = new Random();
            for (int i = 0; i < 30; i++)
                cars[i] = new Car(rnd.Next(2, 10), 1000 + rnd.Next(-400, 400), "Volvo v" + Convert.ToString( rnd.Next(1,9)*10), 2015 + rnd.Next(-10, 5), 200 + rnd.Next(-2, 15) * 10);
            using (FileStream fs = new FileStream("cars.xml", FileMode.Truncate))
            {
                xml.Serialize(fs, cars);
            }

            XPathDocument xmldoc = new XPathDocument("cars.xml");
            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//Transport/Weight"))
                Console.Write(x.Value + " ");

            Console.WriteLine();

            foreach (XPathItem x in xmldoc.CreateNavigator().Select("//Transport[Max_speed > '280']/Name"))             
                Console.WriteLine(x);

            Console.WriteLine("\n--------------------------------------------------------------------------------\n");

            XDocument xdoc = XDocument.Load("cars.xml");
            XElement root = xdoc.Element("ArrayOfTransport");
            foreach (XElement xe in root.Elements("Transport").Where(x => Convert.ToInt32(x.Element("Year").Value) < 2015).ToList())
            {
                if (Convert.ToInt32(xe.Element("Seats").Value) < 5 || Convert.ToInt32(xe.Element("Max_speed").Value) < 220)
                { 
                    xe.Remove();
                }
            }
            root.Add(new XElement("Transport",
                        new XElement("Seats", "5"),
                        new XElement("Weight", "1200"),
                        new XElement("Name", "Mistubishi"),
                        new XElement("Max_speed", "280"),
                        new XElement("Year", "2018")
                      ));
            xdoc.Save("newCars.xml");

            Console.WriteLine(xdoc);

        }
    }
}
