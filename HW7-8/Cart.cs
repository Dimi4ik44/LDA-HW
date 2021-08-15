using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Cart
    {
        public Product[] Products { get; set; }
        public bool addProduct(Product p)
        {
            Product[] temp = new Product[Products.Length];
            for (int i = 0; i < Products.Length; i++)
            {
                temp[i] = Products[i];
            }
            temp[temp.Length - 1] = p;
            return true;
        }
        public bool removeProduct(Product p)
        {
            if(Products.Length <= 0)
            {
                return false;
            }
            Product[] temp = new Product[Products.Length - 1];
            int counter = 0;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i] == p) continue;
                temp[counter] = Products[i];
                counter++;
            }
            return true;
        }
    }
}
