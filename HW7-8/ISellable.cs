using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    interface ISellable
    {
        public int Price { get; set; }
        public int Ammount { get; set; }

        public bool Sell(int count);


    }
}
