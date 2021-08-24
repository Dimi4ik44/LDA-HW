using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8.Products
{
    class Conserve : Product
    {
        public Conserve(string name, DateTime UseDate, int ammount,int price, float mass, Brand brand) : base(name, UseDate, ammount, price, mass, brand)
        {
        }
    }
}
