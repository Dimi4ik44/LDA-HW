using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class HomeNumber : PhoneNumber
    {
        public bool CreateNumber(int number)
        {
            Number = number.ToString();         
            return true;
        }
    }
}
