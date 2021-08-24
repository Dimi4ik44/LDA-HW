using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8.Products
{
    class Water : Product
    {
        public float Capacity { get; set; }
        public Water(string name, DateTime UseDate, int ammount,int price, float mass, Brand brand, float capacity) : base(name, UseDate, ammount, price, mass, brand)
        {
            Capacity = capacity;
        }
    }
}
