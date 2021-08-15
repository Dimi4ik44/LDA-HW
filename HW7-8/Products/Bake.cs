using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8.Products
{
    class Bake : Product
    {
        public Bake(string name, DateTime UseDate, int ammount, float mass, Brand brand) : base(name, UseDate, ammount, mass, brand)
        {
        }
    }
}
