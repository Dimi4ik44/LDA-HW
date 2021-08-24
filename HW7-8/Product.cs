using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    abstract class Product : ISellable, IFreshState
    {
        public DateTime DateOfManufacture { get; private set; }
        public DateTime UseUntil { get; private set; }
        public string NameOfProduct { get; private set; }
        public string Description { get; set; }
        public Brand _Brand { get; set; }
        public int Price { get; set; }
        public int Ammount { get; set; }
        public float Mass { get; set; }
        public Product(string name,DateTime UseDate, int ammount,int price, float mass, Brand? brand)
        {
            DateOfManufacture = DateTime.Now;
            SetUseUntil(UseDate);
            NameOfProduct = name;
            Mass = mass;
            Ammount = ammount;
            Price = price;
            _Brand = brand == null ? new Brand("Empty") : brand;
        }
        public int SetUseUntil(DateTime date)
        {
            // 0 - All done, 1 - Date selected now, 2 - nothing been changed
            if(DateOfManufacture > date)
            {
                if (UseUntil == new DateTime())
                {
                    UseUntil = DateTime.Now;
                    return 1;
                }
                return 2;
            }
            UseUntil = date;
            return 0;
        }
        public bool ChangeName(string name)
        {
            NameOfProduct = name;
            return true;
        }
        public bool ChangeDescription(string desc)
        {
            Description = desc;
            return true;
        }
        public bool ProductFreshCheck()
        {
            if(UseUntil < DateTime.Now)
            {
                return false;
            }
            return true;
        }
        public bool Sell(int count)
        {
            return false;
        }
    }
}
