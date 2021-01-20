using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class WrongInputException : Exception
    {
        public WrongInputException() { }   
        public WrongInputException(string message) : base(message) { }   
        public WrongInputException(string message, int wrong_value) : base(message)
        {
            Value = wrong_value;
        }

        private int wrong_value;

        public int Value
        {
            get => wrong_value;
            set => wrong_value = value;
        }
    }
}
