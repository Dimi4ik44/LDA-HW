using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Position
    {
        public bool Inited { get; private set; }
        public int Salary { get; set; }
        public string Name { get; set; }
        public Position()
        {
            Salary = 0;
            Name = "NotSelected";
            Inited = false;

        }
        public Position(string name, int salary)
        {
            Salary = salary;
            Name = name;
            Inited = true;

        }
        public int getSalary()
        {
            return Salary;
        }
    }
}
