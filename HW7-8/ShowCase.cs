using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class ShowCase
    {
        public int Id { get; private set; }
        public DateTime LastArrival { get; private set; }
        public Product[] ProductsInside { get; private set; }
        public ShowCase(int id)
        {
            ProductsInside = new Product[0];
            Id = id;
        }
        public void ShowProducts()
        {
            for (int i = 0; i < ProductsInside.Length; i++)
            {
                Product p = ProductsInside[i];
                Console.WriteLine($"{p.NameOfProduct}  DateCreate: {p.DateOfManufacture}  DateUse: {p.UseUntil}  Desc:{p.Description}");
            }
        }
        public bool RefillProducts(Product[] products)
        {
            LastArrival = DateTime.Now;
            ProductsInside = ProductsInside.ProductsAppend(products);
            return true;
        }
        public void RemoveSpoiledProducts()
        {
            for (int i = 0; i < ProductsInside.Length; i++)
            {
                if (!ProductsInside[i].ProductFreshCheck())
                {
                    ProductsInside = ProductsInside.ProductRemoveByIndex(i);
                    i--;
                }
            }
        }
    }
}
