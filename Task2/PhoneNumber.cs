using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task2
{
    abstract class PhoneNumber : INumber
    {
        public string Number { get; set; }
        public override string ToString()
        {
            return Number;
        }
    }
}
