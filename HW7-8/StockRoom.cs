using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class StockRoom
    {
        public int IdStock { get; set; }
        public int ProductCount { get; set; }
        public DateTime LastArrival { get; set; }
        public Product[] ProductsInStock { get; set; }
        public StockRoom(int id)
        {
            IdStock = id;
            ProductsInStock = new Product[0];
        }
        private void RefreshCount()
        {
            ProductCount = ProductsInStock.Length;
        }
        public bool RefillProducts(Product[] products)
        {
            ProductsInStock = ProductsInStock.ProductsAppend(products);
            RefreshCount();
            return true;
        }
        public void RemoveSpoiledProducts()
        {
            for (int i = 0; i < ProductsInStock.Length; i++)
            {
                if(!ProductsInStock[i].ProductFreshCheck())
                {
                    ProductsInStock = ProductsInStock.ProductRemoveByIndex(i);
                    i--;
                }
            }
            RefreshCount();
        }
    }
}
