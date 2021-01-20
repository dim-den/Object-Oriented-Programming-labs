using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OOPLab8
{
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(Train))]
    [XmlInclude(typeof(ExpressTrain))]
    interface IntTransport
    {
        double Weight { get; set; }
        int Seats { get; set; }
        string Name { get; set; }
    }
}
