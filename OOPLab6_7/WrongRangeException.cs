using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class WrongRangeException : WrongInputException
    {

        public WrongRangeException() { }
        public WrongRangeException(string message) : base(message) { }
        public WrongRangeException(string message, int min, int max) : base(message)
        {
            this.min = min;
            this.max = max;
        }

        private int min;
         
        public int Min
        {
            get => min;
            set => min = value;
        }
        private int max;
        public int Max
        {
            get => max;
            set => max = value; 
        }
        
    }
}
