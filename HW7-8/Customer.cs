using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Customer : Person
    {
        public int SpentMoneyValue { get; set; }
        public int CurrentMoneyValue { get; set; }
        public Cart _Cart { get; set; }
        public Customer(string name, int age, int moveSpeed) : base(name, age, moveSpeed)
        {
            _Cart = new Cart();
        }

        public Customer(string name, int age, string about, int moveSpeed = 0) : base(name, age, about, moveSpeed)
        {
            _Cart = new Cart();
        }
        public Customer(string name, int age, string about, int money, int moveSpeed = 0) : base(name, age, about, moveSpeed)
        {
            _Cart = new Cart();
            CurrentMoneyValue = money;
        }
    }
}
