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

        }
        private void RefreshCount()
        {
            ProductCount = ProductsInStock.Length;
        }
        public bool RefillProducts(Product[] products)
        {
            ProductsInStock.ProductsAppend(products);
            RefreshCount();
            return true;
        }
        public void RemoveSpoiledProducts()
        {
            //ProductsInStock
        }
    }
}
