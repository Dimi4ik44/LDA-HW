using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class ShowCase
    {
        public int Id { get; private set; }
        public Product[] ProductsInide { get; set; }
        public ShowCase(int id)
        {
            ProductsInide = new Product[0];
            Id = id;
        }
        public void ShowProducts()
        {
            for (int i = 0; i < ProductsInide.Length; i++)
            {
                Product p = ProductsInide[i];
                Console.WriteLine($"{p.NameOfProduct}  DateCreate: {p.DateOfManufacture}  DateUse: {p.UseUntil}  Desc:{p.Description}");
            }
        }
    }
}
