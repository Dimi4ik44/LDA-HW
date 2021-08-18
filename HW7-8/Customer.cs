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

        public Customer(string name, int age, int moveSpeed, string about) : base(name, age, moveSpeed, about)
        {
            _Cart = new Cart();
        }
        public Customer(string name, int age, int moveSpeed, string about, int money) : base(name, age, moveSpeed, about)
        {
            _Cart = new Cart();
            CurrentMoneyValue = money;
        }
    }
}
