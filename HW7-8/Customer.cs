using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Customer : Person
    {
        public int SpentMoney { get; set; }
        public int CountMoney { get; set; }
        public Cart _Cart { get; set; }
        public Customer(string name, int age, int moveSpeed) : base(name, age, moveSpeed)
        {
            _Cart = new Cart();
            SpentMoney = 0;
        }

        public Customer(string name, int age, int moveSpeed, string about) : base(name, age, moveSpeed, about)
        {
            _Cart = new Cart();
            SpentMoney = 0;
        }
        public Customer(string name, int age, int moveSpeed, string about, int money) : base(name, age, moveSpeed, about)
        {
            _Cart = new Cart();
            SpentMoney = 0;
            CountMoney = money;
        }
    }
}
