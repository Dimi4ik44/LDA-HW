using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class StockRoom
    {
        public int IdStock { get; private set; }
        public int ProductCount { get; private set; }
        public DateTime LastArrival { get; private set; }
        public Product[] ProductsInStock { get; private set; }
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
            LastArrival = DateTime.Now;
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
