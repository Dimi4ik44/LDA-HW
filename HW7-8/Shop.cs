using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Shop
    {
        public int ShopId { get; private set; }
        public string ShopName { get; private set; }
        public Employee[] Employees { get; set; }
        public Customer[] Customers { get; set; }
        public StockRoom[] Stocks { get; set; }
        public ShowCase[] ShowCases { get; set; }

        public Shop(int id, string name, Employee[] employee, StockRoom[] stocks, ShowCase[] showcases)
        {
            ShopId = id;
            ShopName = name;
            Customers = new Customer[0];
            Employees = employee == null ? new Employee[0] : employee;
            Stocks = stocks == null ? new StockRoom[0] : stocks;
            ShowCases = showcases == null ? new ShowCase[0] : showcases;
        }
        public bool setShopName(string name)
        {
            ShopName = name;
            return true;
        }

    }
}
