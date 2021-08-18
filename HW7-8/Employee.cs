using System;
using System.Collections.Generic;
using System.Text;

namespace HW7_8
{
    class Employee : Person
    {
        public int Salary { get; private set; }
        public Position _Position { get; private set; }
        public Employee(string name, int age, Position position, int moveSpeed = 0) : base(name, age, moveSpeed)
        {
            _Position = position;
            Salary = position.getSalary();
        }

        public Employee(string name, int age, string about, Position position, int moveSpeed = 0) : base(name, age, about, moveSpeed)
        {
            _Position = position;
            Salary = position.getSalary();
        }
        public void SetEmployeePos(Position pos)
        {
            _Position = pos;
            Salary = pos.getSalary();
        }
    }
}
