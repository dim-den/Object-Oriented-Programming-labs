using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab6
{
    class WrongIndexException : WrongInputException
    {
        private int max_value = -1;
        public int Max
        {
            get => max_value;
            set => max_value = value;
        }
        public WrongIndexException(string message) : base(message) { }

        public WrongIndexException(string message, int wrong_value) : base(message, wrong_value) { }
        public WrongIndexException(string message, int wrong_value, int max_value) : base(message, wrong_value)
        {
            this.max_value = max_value;
        }
    }
}
