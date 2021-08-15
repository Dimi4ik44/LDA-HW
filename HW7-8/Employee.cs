using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Employee : Person
    {
        public int Salary { get; set; }
        public Positions.PositionList Position { get; set; }
        public Employee(string name, int age, int moveSpeed, Positions.PositionList position) : base(name, age, moveSpeed)
        {
            Position = position;
            Positions p = new Positions();
            Salary = p.getSallory(Position);
        }

        public Employee(string name, int age, int moveSpeed, string about, Positions.PositionList position) : base(name, age, moveSpeed, about)
        {
            Position = position;
            Positions p = new Positions();
            Salary = p.getSallory(Position);
        }
    }
}
