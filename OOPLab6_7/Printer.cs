using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class Printer
    {
        virtual public void IAmPrinting(Transport obj)
        {
            if (obj is Car)
            {
                Console.WriteLine(obj.ToString()); ;
            }
            else if (obj is Train)
            {
                Console.WriteLine(obj.ToString());
            }
            else if (obj is ExpressTrain)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
