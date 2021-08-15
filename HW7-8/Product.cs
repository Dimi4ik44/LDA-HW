using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Product
    {
        public DateTime DateOfManufacture { get; private set; }
        public DateTime UseUntil { get; private set; }
        public string NameOfProduct { get; private set; }
        public string Description { get; set; }

        public Product(string name,DateTime UseDate)
        {
            DateOfManufacture = DateTime.Now;
            SetUseUntil(UseDate);
            NameOfProduct = name;
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
    }
}
