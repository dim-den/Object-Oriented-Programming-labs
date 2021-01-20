using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab8
{
    interface IList<T> where T : Transport
    {
        List<T> Add(T value);
        List<T> Pop();
        void Print();
    }

}
